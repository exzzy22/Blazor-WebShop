using System.Text.Json;

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

    [HttpGet("carousel/topSelling")]
    public async Task<IActionResult> GetCarouselTopSelling()
    {
        var carousel = await _service.ProductService.GetCarouselProductsAsync(x => (x.Sold));

        return Ok(carousel);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddProduct(ProductForCreationDto product)
    {
        await _service.ProductService.AddProduct(product);

        return Ok();
    }
}
