using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Shared.ConfigurationModels.Configuration;
using Shared.DataTransferObjects;
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
        foreach (ImageForCreationDto image in product.Images)
        {
            image.ImageDataUrl = image.ImageDataUrl.SaveDataUrlToFile($"{_imagePath}{Guid.NewGuid()}{image.FileExtension}");
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
        foreach (ImageForCreationDto image in product.Images)
        {
            if (!image.ImageDataUrl.StartsWith("http"))
                image.ImageDataUrl = image.ImageDataUrl.SaveDataUrlToFile($"{_imagePath}{Guid.NewGuid()}{image.FileExtension}");

            else
                image.ImageDataUrl = image.ImageDataUrl.Split("image/")[1];
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
    public async Task<IEnumerable<ProductCarouselDto>> GetCarouselProductsAsync<T>(Expression<Func<Product, T>> orderBy, int numberOfProducts)
    {
        IEnumerable<Product> products = await _repository.Product.GetProductsAsync(orderBy, numberOfProducts);

        return _mapper.Map<IEnumerable<ProductCarouselDto>>(products);
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

        foreach (var image in productForCreation.Images)
        {
            image.ImageDataUrl = $"{_accessor?.HttpContext?.Request.Scheme}://{_accessor?.HttpContext?.Request.Host}{_accessor?.HttpContext?.Request.PathBase}/image/{image.ImageDataUrl}";
        }

        return productForCreation;
    }

    public void DeleteImage(string name)
    {
        if (File.Exists(_imagePath + name))
        {
            File.Delete(_imagePath + name);
        }
    }

    public void DeleteImage(List<string> names)
    {
        foreach (string name in names)
        {
            if (File.Exists(_imagePath + name))
            {
                File.Delete(_imagePath + name);
            }
        }
    }

    public async Task<IEnumerable<ImageForTableDto>> GetListOfUnusedImages()
    {
        string[] images = Directory.GetFiles(_imagePath).Select(filePath => Path.GetFileName(filePath)).ToArray();

        List<Image> dbImages = await _repository.Image.GetAllImages(false);

        List<ImageForTableDto> imageForTables= new();

        foreach (var image in images.Except(dbImages.Select(i => i.File)))       
        {
            imageForTables.Add(new ImageForTableDto(image, $"{_accessor?.HttpContext?.Request.Scheme}://{_accessor?.HttpContext?.Request.Host}{_accessor?.HttpContext?.Request.PathBase}/image/{image}"));
        }

        return imageForTables;
    }

    public async Task<CartDto> GetCart(int cartId) => _mapper.Map<CartDto>(await _repository.Cart.GetCartAsync(cartId, false));

	public async Task<CartDto> AddProductToCart(int productId, int cartId, int quantity)
	{
        if (cartId == default)
        {
            Cart cartToCreate = new Cart { Products = new List<ProductCart> { new ProductCart { ProductId = productId, Quantity = 1 }}};
			_repository.Cart.Create(cartToCreate);

			await _repository.SaveAsync();

			return _mapper.Map<CartDto>(cartToCreate);
		}

		Cart dbCart = await _repository.Cart.GetCartAsync(cartId, true) ?? throw new CartNotFound(cartId);

        if (dbCart.Products.Any(p => p.ProductId == productId))
        {
            dbCart.Products.First(p => p.ProductId == productId).Quantity += quantity;
        }
        else
        {
            dbCart.Products.Add(new ProductCart { ProductId = productId, Quantity = quantity });
		}

		await _repository.SaveAsync();

		return _mapper.Map<CartDto>(_mapper.Map<CartDto>(await _repository.Cart.GetCartAsync(dbCart.Id, false)));
	}

	public async Task<CartDto> RemoveProductFromCart(int productId, int cartId)
	{
		Cart dbCart = await _repository.Cart.GetCartAsync(cartId, true) ?? throw new CartNotFound(cartId);

        dbCart.Products.Remove(dbCart.Products.First(p => p.ProductId == productId));

		await _repository.SaveAsync();

		return _mapper.Map<CartDto>(dbCart);
	}

	public Task<WishlistDto> AddRemoveFromWishlist(int productId)
	{
		throw new NotImplementedException();
	}
}
