namespace Service.Implementations;

internal sealed class ProductService : IProductService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public ProductService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<CarouselDto> GetCarouselProductsAsync()
    {
        var products = await _repository.Product.GetProductsAsync();

        products = products.OrderByDescending(x => (x.Sold * x.Price)).ToList();

        var categories = products.Select(p => p.SubCategory.Category.Name).Distinct().Take(4);

        List<Product> productsList = new ();

        foreach (var category in categories)
        {
            var productsInCategory = products.Where(p => p.SubCategory.Category.Name.Equals(category)).Take(8);
            productsList.AddRange(productsInCategory);
        }

        return new CarouselDto(_mapper.Map<IEnumerable<ProductDto>>(productsList), categories);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var products = await _repository.Product.GetProductsAsync();

        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }
}
