namespace API.Controllers;

[Route("api/product")]
[ApiController]
[AllowAnonymous]
public class ProductController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProductController(IServiceManager service) => _service = service;

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
    public async Task<IActionResult> AddProduct(ProductDto product)
    {
        await _service.ProductService.AddProduct(product);

        return Ok();
    }
}
