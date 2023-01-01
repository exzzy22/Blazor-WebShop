﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Service.Implementations;
using Shared.ConfigurationModels.Configuration;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<ICurrencyService> _currencyService;
        private readonly Lazy<IPaymentService> _paymentService;
        public ServiceManager(IRepositoryManager repositoryManager, 
            ILoggerManager logger, 
            IMapper mapper,
            IHttpContextAccessor accessor,
            UserManager<User> userManager, 
            RoleManager<Role> roleManager, 
            IOptions<JwtConfiguration> jwtConfiguration,
            IOptions<Configuration> configuration,
            IWebHostEnvironment webHostEnvironment)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, roleManager, userManager, jwtConfiguration));
            _productService = new Lazy<IProductService>(()=> new ProductService(repositoryManager,logger,mapper,webHostEnvironment,accessor, configuration));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, logger, mapper));
            _currencyService = new Lazy<ICurrencyService>(() => new CurrencyService(repositoryManager, logger, mapper));
            _paymentService = new Lazy<IPaymentService>( () => new StripeService(configuration,repositoryManager,mapper));
        }
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IProductService ProductService => _productService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public ICurrencyService CurrencyService => _currencyService.Value;
        public IPaymentService PaymentService => _paymentService.Value;
    }
}