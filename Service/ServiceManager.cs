using Service.Implementations;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IProductService> _productService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IOptions<JwtConfiguration> configuration)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
            _productService = new Lazy<IProductService>(()=> new ProductService(repositoryManager,logger,mapper));
        }
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IProductService ProductService => _productService.Value;
    }
}