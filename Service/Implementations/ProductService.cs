using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Shared.ConfigurationModels.Configuration;
using Shared.Extensions;

namespace Service.Implementations;

internal sealed class ProductService : IProductService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _accessor;
    private readonly Configuration _configuration;
    private readonly string _imagePath;
    public ProductService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor accessor, IOptions<Configuration> configuration)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _webHostEnvironment = webHostEnvironment;
        _configuration = configuration.Value;
        _imagePath = webHostEnvironment.WebRootPath + _configuration.FilePathConfiguration.Image;
        _accessor = accessor;
    }

    public async Task<ProductDto> GetProductAsync(int productId)
    {
        Product product = await _repository.Product.GetProductAsync(productId, false) ?? throw new ProductNotFound(productId);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task AddProductAsync(ProductForCreationDto product)
    {
        // Switch ImageDataUrl with saved file name
        foreach (PictureForCreationDto picture in product.Pictures)
        {
            picture.ImageDataUrl = picture.ImageDataUrl.SaveDataUrlToFile($"{_imagePath}{Guid.NewGuid()}{picture.FileExtension}");
        }

        Product productToInsert = _mapper.Map<Product>(product);
        _repository.Product.Create(productToInsert);

        await _repository.SaveAsync();
    }

    public async Task DeleteProductAsync(int productId)
    {
        Product product = await _repository.Product.GetProductAsync(productId, false) ?? throw new ProductNotFound(productId);
        _repository.Product.Delete(product);
        await _repository.SaveAsync();
    }
    public async Task UpdateProductAsync(ProductForCreationDto product)
    {
        if (product.Id is null)
            throw new ProductNotFound();

        // Switch ImageDataUrl with saved file name
        foreach (PictureForCreationDto picture in product.Pictures)
        {
            if (!picture.ImageDataUrl.StartsWith("http"))
                picture.ImageDataUrl = picture.ImageDataUrl.SaveDataUrlToFile($"{_imagePath}{Guid.NewGuid()}{picture.FileExtension}");

            else
                picture.ImageDataUrl = picture.ImageDataUrl.Split("image/")[1];
        }

        Product dBproduct = await _repository.Product.GetProductAsync((int)product.Id, true) ?? throw new ProductNotFound((int)product.Id);
        Product updated = _mapper.Map(product, dBproduct);
        _repository.Product.Update(updated);
        await _repository.SaveAsync();

    }

    public async Task UpdateProductAsync(ProductDto product)
    {
        Product dBproduct = await _repository.Product.GetProductAsync(product.Id, false) ?? throw new ProductNotFound(product.Id);
        Product updated = _mapper.Map(product, dBproduct);
        _repository.Product.Update(updated);
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

    public async Task<ProductForCreationDto> GetProductForUpdateAsync(int productId)
    {
        Product product = await _repository.Product.GetProductAsync(productId, false) ?? throw new ProductNotFound(productId);

        ProductForCreationDto productForCreation = _mapper.Map<ProductForCreationDto>(product);

        foreach (var picture in productForCreation.Pictures)
        {
            picture.ImageDataUrl = $"{_accessor?.HttpContext?.Request.Scheme}://{_accessor?.HttpContext?.Request.Host}{_accessor?.HttpContext?.Request.PathBase}/image/{picture.ImageDataUrl}";
        }

        return productForCreation;
    }
}
