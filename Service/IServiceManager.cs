namespace Service
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        ICurrencyService CurrencyService { get; }
        IPaymentService PaymentService { get; }

    }
}