using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class ProductController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProductController(IServiceManager service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _service.ProductService.GetProductsAsync();

        return Ok(products);
    }
}
