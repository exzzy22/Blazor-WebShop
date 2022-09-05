using System.Linq.Expressions;

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

    public async Task<IEnumerable<CarouselDto>> GetCarouselProductsAsync<T>(Expression<Func<Product, T>> orderBy, int numberOfCategories,int numberOfProducts)
    {
        IEnumerable<Product> products = await _repository.Product.GetProductsAsync();

        IEnumerable<Category> categories = _repository.Category.GetTopCategoriesAsync(orderBy,numberOfCategories);

        List<CarouselDto> carousel = new ();

        foreach (var category in categories)
        {
            carousel.Add(
                new CarouselDto (
                Category: _mapper.Map<CategoryDto>(category),
                Products: _mapper.Map<IEnumerable<ProductDto>>(products.Where(p => p.SubCategory.Category.Id.Equals(category.Id)).Take(numberOfProducts))));
        }

        return carousel;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var products = await _repository.Product.GetProductsAsync();

        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }
}
