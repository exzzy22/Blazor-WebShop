namespace API.Controllers;

[Route("api/product")]
[ApiController]
[AllowAnonymous]
public class ProductController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProductController(IServiceManager service) => _service = service;

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProduct(int productId)
    {
        ProductDto product = await _service.ProductService.GetProduct(productId);

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
    public async Task<IActionResult> AddProduct(ProductDto product)
    {
        await _service.ProductService.AddProduct(product);

        return StatusCode(201);
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
}
