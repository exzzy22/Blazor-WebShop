﻿using Configuration = Shared.ConfigurationModels.Configuration.Configuration;

namespace Service.Implementations;

internal sealed class PaymentService : IPaymentService
{
    private readonly Configuration _configuration;
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
	private readonly string _documentPath;

	public PaymentService(ILoggerManager logger,IOptions<Configuration> configuration,IRepositoryManager repositoryManager,IMapper mapper, IWebHostEnvironment webHostEnvironment)
	{
        _logger = logger;
        StripeConfiguration.ApiKey = configuration.Value.Stripe.SecretKey;
        _configuration = configuration.Value;
        _repositoryManager = repositoryManager;
        _mapper = mapper;
		_documentPath = webHostEnvironment.WebRootPath + _configuration.FilePathConfiguration.Document;
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
			Prodcuts = GenerateOrderProducts(cart, order)
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
                        UnitAmountDecimal = (int)(Math.Round(orderToCreate.Amount,2,MidpointRounding.AwayFromZero)*100), 
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

        try
        {
            InvoiceDocument document = new(order);

			string guid = Guid.NewGuid().ToString();
			_logger.LogInfo($"Creating pdf invoice: {guid}");

			document.GeneratePdf($"{_documentPath}{guid}.pdf");
            order.Invoice = guid;

            await _repositoryManager.SaveAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error creating invoice: "+ex.Message);
        }
        
        return true;
    }

    List<ProductOrder> GenerateOrderProducts(Cart cart, OrderForCreationDto order)
    {
		List<ProductOrder> productOrders= new ();

        foreach (var product in cart.Products) 
        {
            productOrders.Add(new ProductOrder 
            {
                Price = product.Product.Prices.First(p => p.Currency.ISO4217.Equals(order.CurrencyISO)).Value,
                CurrencyISO4217 = order.CurrencyISO,
                CurrencySymbol = product.Product.Prices.First(p => p.Currency.ISO4217.Equals(order.CurrencyISO)).Currency.Symbol,
                Discount = product.Product.Discount,
                TotalPrice = CalculateDiscountedPrice(product.Product.Prices.First(p => p.Currency.ISO4217.Equals(order.CurrencyISO)).Value, product.Product.Discount)*product.Quantity,
				Quantity = product.Quantity,
                Name = product.Product.Name,
                ShortName = product.Product.ShortName,
            });
        }

        return productOrders;
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

	double CalculateDiscountedPrice(double price, int discount) => price - price * (discount / 100.0);
}
