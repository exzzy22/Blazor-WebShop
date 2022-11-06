namespace API.Controllers;

[Route("api/product")]
[ApiController]
[AllowAnonymous]
public class ProductController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProductController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProduct(int productId)
    {
        ProductDto product = await _service.ProductService.GetProductAsync(productId);

        return Ok(product);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetProducts()
    {
        IEnumerable<ProductDto>? products = await _service.ProductService.GetProductsAsync();

        return Ok(products);
    }

    [HttpGet("carousel/topSelling/{numberOfCategories}/{numberOfProducts}")]
    public async Task<IActionResult> GetCarouselTopSelling(int numberOfCategories, int numberOfProducts)
    {
        var carousel = await _service.ProductService.GetCarouselProductsAsync(p => (p.Sold), numberOfCategories, numberOfProducts);

        return Ok(carousel);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddProduct(ProductForCreationDto product)
    {
        await _service.ProductService.AddProductAsync(product);

        return StatusCode(201);
    }

    [HttpDelete("delete/{productId}")]
    public async Task<IActionResult> DeleteProduct(int productId)
    {
        await _service.ProductService.DeleteProductAsync(productId);

        return NoContent();
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateProduct(ProductDto product)
    {
        await _service.ProductService.UpdateProductAsync(product);

        return Ok();
    }

    [HttpPost("category/add")]
    public async Task<IActionResult> AddCategory(CategoryDto category)
    {
        await _service.CategoryService.AddCategory(category);

        return StatusCode(201);
    }

    [HttpPost("category/delete/{categoryId}")]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        await _service.CategoryService.DeleteCategory(categoryId);

        return NoContent();
    }

    [HttpPost("category/update")]
    public async Task<IActionResult> UpdateCategory(CategoryDto category)
    {
        await _service.CategoryService.UpdateCategory(category);

        return Ok();
    }

    [HttpGet("category/all")]
    public async Task<IActionResult> GetCategories()
    {
        IEnumerable<CategoryDto> categories = await _service.CategoryService.GetCategoriesAsync();

        return Ok(categories);
    }

    [HttpGet("currency/all")]
    public async Task<IActionResult> Getcurrencies()
    {
        IEnumerable<CurrencyDto> currencies = await _service.CurrencyService.GetCurrenciesAsync();

        return Ok(currencies);
    }

    [HttpPost("currency/add")]
    public async Task<IActionResult> Addcurrency(CurrencyDto currency)
    {
        await _service.CurrencyService.AddCurrencyAsync(currency);

        return StatusCode(201);
    }

    [HttpPost("currency/delete/{currencyId}")]
    public async Task<IActionResult> Deletecurrency(int currencyId)
    {
        await _service.CurrencyService.DeleteCurrencyAsync(currencyId);

        return NoContent();
    }

    [HttpPost("currency/update")]
    public async Task<IActionResult> Updatecurrency(CurrencyDto currency)
    {
        await _service.CurrencyService.UpdateCurrencyAsync(currency);

        return Ok();
    }

}
