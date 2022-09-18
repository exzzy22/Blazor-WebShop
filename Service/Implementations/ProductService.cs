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

    public async Task AddProduct(ProductForCreationDto product)
    {
        var attributes = GetAttributesType(product.DerivedType, product.AttributesJSON);
        _repository.Attributes.Create(attributes);


        var productToInsert = _mapper.Map<Product>(product);
        productToInsert.Attributes = attributes;
        _repository.Product.Create(productToInsert);
        await _repository.SaveAsync();
    }
    public async Task<CarouselDto> GetCarouselProductsAsync<T>(Expression<Func<Product, T>> orderBy)
    {
        IEnumerable<Product> products = await _repository.Product.GetProductsAsync();

        IEnumerable<Category> categories = _repository.Category.GetTopCategoriesAsync(orderBy,4);

        List<Product> filteredProducts = new();

        foreach (Category category in categories)
        {
            var categoryProducts = products.Where(p => p.Category.Id.Equals(category.Id)).Take(8);
            if (categoryProducts.Count() != 8)
                throw new ProductCountNotFound(category.Name);

            filteredProducts.AddRange(categoryProducts);
        }

        return new CarouselDto(_mapper.Map<IEnumerable<CategoryDto>>(categories),_mapper.Map<IEnumerable<ProductForCreationDto>>(filteredProducts));
    }

    public async Task<IEnumerable<ProductForCreationDto>> GetProductsAsync()
    {
        var products = await _repository.Product.GetProductsAsync();

        return _mapper.Map<IEnumerable<ProductForCreationDto>>(products);
    }

    private dynamic? GetAttributesType(string derivedType, string json)
    {
        switch (derivedType)
        {
            case nameof(CpuAtrributesForCreationDto):
                    return _mapper.Map<CpuAtrributes>(JsonSerializer.Deserialize<CpuAtrributesForCreationDto>(json));

        }

        return null;
    }
}
