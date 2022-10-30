using Service.Implementations;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<ICategoryService> _categoryService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager, IOptions<JwtConfiguration> configuration)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, roleManager, userManager, configuration));
            _productService = new Lazy<IProductService>(()=> new ProductService(repositoryManager,logger,mapper));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, logger, mapper));
        }
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IProductService ProductService => _productService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
    }
}