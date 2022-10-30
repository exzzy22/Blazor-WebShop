using System.Text.Json;

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

    public async Task<ProductDto> GetProduct(int productId)
    {
        Product? product = await _repository.Product.GetProductAsync(productId, false);
        if (product is null)
            throw new ProductNotFound(productId);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task AddProduct(ProductDto product)
    {
        Product productToInsert = _mapper.Map<Product>(product);
        _repository.Product.Create(productToInsert);
        await _repository.SaveAsync();
    }

    public async Task<CarouselDto> GetCarouselProductsAsync<T>(Expression<Func<Product, T>> orderBy, int numberOfCategories, int numberOfProducts)
    {
        IEnumerable<Product> products = await _repository.Product.GetProductsAsync();

        IEnumerable<Category> categories = _repository.Category.GetTopCategoriesAsync(orderBy,numberOfCategories);

        List<Product> filteredProducts = new();

        foreach (Category category in categories)
        {
            var categoryProducts = products.Where(p => p.Category.Id.Equals(category.Id)).Take(numberOfProducts);
            if (categoryProducts.Count() != numberOfProducts)
                throw new ProductCountNotFound(category.Name, numberOfProducts);

            filteredProducts.AddRange(categoryProducts);
        }

        return new CarouselDto(_mapper.Map<IEnumerable<CategoryDto>>(categories),_mapper.Map<IEnumerable<ProductCarouselDto>>(filteredProducts));
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        IEnumerable<Product> products = await _repository.Product.GetProductsAsync();

        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }
}
