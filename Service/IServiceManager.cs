namespace Service
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IProductService ProductService { get; }
    }
}