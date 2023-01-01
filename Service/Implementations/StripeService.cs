using Stripe;
using System.Configuration;
using Shared.ConfigurationModels.Configuration;
using Configuration = Shared.ConfigurationModels.Configuration.Configuration;
using Domain.Models;
using Stripe.Checkout;

namespace Service.Implementations;

internal sealed class StripeService : IPaymentService
{
    private readonly Configuration _configuration;
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
	public StripeService(IOptions<Configuration> configuration,IRepositoryManager repositoryManager,IMapper mapper)
	{
        StripeConfiguration.ApiKey = configuration.Value.Stripe.SecretKey;
        _configuration = configuration.Value;
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<string> CreatePaymentUrl(OrderDto order)
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
                    PriceData = new SessionLineItemPriceDataOptions { UnitAmountDecimal = GetCartTotal(order.CurrencyISO,cart.Products.ToList()), Currency = order.CurrencyISO, ProductData = new SessionLineItemPriceDataProductDataOptions { Name = "WebShop" } }
                }
            } ,
            Mode = "payment",
            SuccessUrl = _configuration.BaseUrls.WebShop + orderToCreate.Id,
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

	decimal GetCartTotal(string currencyIsoCode, List<ProductCart> products)
	{
		double sum = 0;

		foreach (var product in products)
		{
            double price = product.Product.Prices.First(p => p.Currency.ISO4217.Equals(currencyIsoCode)).Value;
			sum += product.Quantity * CalculateDiscountedPrice(price, product.Product.Discount);
		}

		return (decimal)sum*100;
	}

	double CalculateDiscountedPrice(double price, double discount) => price - price * (discount / 100.0);
}
