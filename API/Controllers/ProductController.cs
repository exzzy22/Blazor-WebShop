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
        var products = await _service.ProductService.GetProductsAsync();

        return Ok(products);
    }

    [HttpGet("carousel/topSelling")]
    public async Task<IActionResult> GetCarouselTopSelling(int numberOfCategories, int numberOfProducts)
    {
        var carousel = await _service.ProductService.GetCarouselProductsAsync(x => (x.Sold * x.Price), numberOfCategories,numberOfProducts);

        return Ok(carousel);
    }
}
