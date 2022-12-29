using Domain.Models;
using Service.Contracts;
using System.Reflection.Metadata.Ecma335;

namespace API.Controllers;

[Route("api/product")]
[ApiController]
[AllowAnonymous]
public class ProductController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public ProductController(IServiceManager service)
    {
        _serviceManager = service;
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProduct(int productId)
    {
        ProductDto product = await _serviceManager.ProductService.GetProductAsync(productId);

        return Ok(product);
    }

    [HttpGet("update/{productId}")]
    public async Task<IActionResult> GetProductForUpdate(int productId)
    {
        ProductForCreationDto product = await _serviceManager.ProductService.GetProductForUpdateAsync(productId);

        return Ok(product);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetProducts()
    {
        IEnumerable<ProductDto>? products = await _serviceManager.ProductService.GetProductsAsync();

        return Ok(products);
    }

    [HttpGet("carousel/topSelling/{numberOfProducts}")]
    public async Task<IActionResult> GetCarouselTopSelling(int numberOfProducts)
    {
        IEnumerable<ProductCarouselDto> carousel = await _serviceManager.ProductService.GetCarouselProductsAsync(p => (p.Sold), numberOfProducts);

        return Ok(carousel);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddProduct(ProductForCreationDto product)
    {
        await _serviceManager.ProductService.AddProductAsync(product);

        return StatusCode(201);
    }

    [HttpDelete("delete/{productId}")]
    public async Task<IActionResult> DeleteProduct(int productId)
    {
        await _serviceManager.ProductService.DeleteProductAsync(productId);

        return NoContent();
    }
    [HttpPost("update/detailed")]
    public async Task<IActionResult> UpdateProduct(ProductForCreationDto product)
    {
        await _serviceManager.ProductService.UpdateProductAsync(product);

        return Ok();
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateProduct(ProductDto product)
    {
        await _serviceManager.ProductService.UpdateProductAsync(product);

        return Ok();
    }

    [HttpPost("category/add")]
    public async Task<IActionResult> AddCategory(CategoryDto category)
    {
        await _serviceManager.CategoryService.AddCategory(category);

        return StatusCode(201);
    }

    [HttpPost("category/delete/{categoryId}")]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        await _serviceManager.CategoryService.DeleteCategory(categoryId);

        return NoContent();
    }

    [HttpPost("category/update")]
    public async Task<IActionResult> UpdateCategory(CategoryDto category)
    {
        await _serviceManager.CategoryService.UpdateCategory(category);

        return Ok();
    }

    [HttpGet("category/all")]
    public async Task<IActionResult> GetCategories() => Ok(await _serviceManager.CategoryService.GetCategoriesAsync());

    [HttpGet("currency/all")]
    public async Task<IActionResult> Getcurrencies() => Ok(await _serviceManager.CurrencyService.GetCurrenciesAsync());

    [HttpPost("currency/add")]
    public async Task<IActionResult> Addcurrency(CurrencyDto currency)
    {
        await _serviceManager.CurrencyService.AddCurrencyAsync(currency);

        return StatusCode(201);
    }

    [HttpPost("currency/delete/{currencyId}")]
    public async Task<IActionResult> Deletecurrency(int currencyId)
    {
        await _serviceManager.CurrencyService.DeleteCurrencyAsync(currencyId);

        return NoContent();
    }

    [HttpPost("currency/update")]
    public async Task<IActionResult> Updatecurrency(CurrencyDto currency)
    {
        await _serviceManager.CurrencyService.UpdateCurrencyAsync(currency);

        return Ok();
    }

    [HttpGet("image/unused")]
    public async Task<IActionResult> GetUnusedImages() => Ok(await _serviceManager.ProductService.GetListOfUnusedImages());

    [HttpPost("image/delete")]
    public async Task<IActionResult> DeleteImage(string image)
    {
        _serviceManager.ProductService.DeleteImage(image);

        return NoContent();
    }

    [HttpPost("image/delete/multiple")]
    public async Task<IActionResult> DeleteImage(List<string> images)
    {
        _serviceManager.ProductService.DeleteImage(images);

        return NoContent();
    }

	[HttpGet("cart/add/{productId}/{cartId}/{quantity}")]
	public async Task<IActionResult> AddProductToCart(int productId, int cartId, int quantity) => Ok(await _serviceManager.ProductService.AddProductToCart(productId,cartId,quantity));
	[HttpGet("cart/remove/{productId}/{cartId}")]
	public async Task<IActionResult> RemoveProductFromCart(int productId, int cartId) => Ok(await _serviceManager.ProductService.RemoveProductFromCart(productId, cartId));

	[HttpGet("cart/{cartId}")]
	public async Task<IActionResult> GetCart(int cartId) => Ok(await _serviceManager.ProductService.GetCart(cartId));

}
