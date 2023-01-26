﻿using Stripe;
using Configuration = Shared.ConfigurationModels.Configuration.Configuration;
using Stripe.Checkout;
using Shared.Extensions;

namespace Service.Implementations;

internal sealed class PaymentService : IPaymentService
{
    private readonly Configuration _configuration;
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
	public PaymentService(IOptions<Configuration> configuration,IRepositoryManager repositoryManager,IMapper mapper)
	{
        StripeConfiguration.ApiKey = configuration.Value.Stripe.SecretKey;
        _configuration = configuration.Value;
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<string> CreatePaymentUrl(OrderForCreationDto order)
    {
        Cart cart = await _repositoryManager.Cart.GetCartAsync(order.CartId,false) ?? throw new CartNotFound(order.CartId);

		Order orderToCreate = new Order
		{
			CartId = cart.Id,
			Email = order.BillingAddress.Email,
			BillingAddress = _mapper.Map<Domain.Models.Address>(order.BillingAddress),
			ShippingAddress = _mapper.Map<Domain.Models.Address>(order.ShippingAddress),
			UserId = cart.UserId,
            StripeId = "",
			CurrencyISO4217 = order.CurrencyISO,
            SessionId = Guid.NewGuid(),
            Amount = GetCartTotal(order.CurrencyISO, cart.Products.ToList()),
		};

		_repositoryManager.Order.Create(orderToCreate);
		await _repositoryManager.SaveAsync();

		var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions> 
            {  
                new SessionLineItemOptions
                { 
                    Quantity = 1,
                    PriceData = new SessionLineItemPriceDataOptions 
                    { 
                        UnitAmountDecimal = (decimal)GetCartTotal(order.CurrencyISO,cart.Products.ToList())*100, 
                        Currency = order.CurrencyISO, 
                        ProductData = new SessionLineItemPriceDataProductDataOptions 
                        { 
                            Name = "Blazor WebShop" 
                        } 
                    }
                }
            } ,
            Mode = "payment",
            SuccessUrl = _configuration.BaseUrls.WebShop + orderToCreate.Id + "/" + orderToCreate.SessionId.ToString().ComputeSha512Hash(),
            CancelUrl = _configuration.BaseUrls.WebShop,
            Currency= order.CurrencyISO,
        };

        var service = new SessionService();
        Session session = service.Create(options);

        Order orderToUpdate = await _repositoryManager.Order.GetOrderAsync(orderToCreate.Id, true);
        orderToUpdate.StripeId = session.Id;
        await _repositoryManager.SaveAsync();

		return session.Url;
    }

    public async Task<bool> ValidatePayment(int orderId, string sessionId)
    {
        Order order = await _repositoryManager.Order.GetOrderAsync(orderId, true);

        if(!order.SessionId.ToString().ComputeSha512Hash().Equals(sessionId))
            return false;

        order.Status = Domain.OrderStatus.Paid;

        await _repositoryManager.SaveAsync();
        
        return true;
    }

    double GetCartTotal(string currencyIsoCode, List<ProductCart> products)
	{
		double sum = 0;

		foreach (ProductCart product in products)
		{
            double price = product.Product.Prices.First(p => p.Currency.ISO4217.Equals(currencyIsoCode)).Value;
			sum += product.Quantity * CalculateDiscountedPrice(price, product.Product.Discount);
		}

		return sum;
	}

	double CalculateDiscountedPrice(double price, double discount) => price - price * (discount / 100.0);
}