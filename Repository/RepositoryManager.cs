namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<ICategoryRepository> _categoryRepository;
    private readonly Lazy<IAttributesRepository> _attributesRepository;
    private readonly Lazy<ICurrencyRepository> _currencyRepository;
    private readonly Lazy<IImageRepository> _imageRepository;
    private readonly Lazy<ICartRepository> _cartRepository;
    private readonly Lazy<IOrderRepository> _orderRepository;


    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
        _attributesRepository = new Lazy<IAttributesRepository>(() => new AttributesRepository(repositoryContext));
        _currencyRepository = new Lazy<ICurrencyRepository>(() => new CurrencyRepository(repositoryContext));
        _imageRepository = new Lazy<IImageRepository>( () => new ImageRepository(repositoryContext));
        _cartRepository = new Lazy<ICartRepository>( () => new CartRepository(repositoryContext));
		_orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));

	}

    public IProductRepository Product => _productRepository.Value;
    public ICategoryRepository Category => _categoryRepository.Value;
    public IAttributesRepository Attributes => _attributesRepository.Value;
    public ICurrencyRepository Currency => _currencyRepository.Value;
    public IImageRepository Image => _imageRepository.Value;
    public ICartRepository Cart => _cartRepository.Value;
    public IOrderRepository Order => _orderRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    public void Save() => _repositoryContext.SaveChanges();
}