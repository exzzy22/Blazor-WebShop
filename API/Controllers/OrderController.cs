using Microsoft.Extensions.Options;
using Shared.ConfigurationModels.Configuration;
using Shared.RequestFeatures;

namespace API.Controllers;

[Route("api/order")]
[ApiController]
[AllowAnonymous]
public class OrderController : ControllerBase
{
    private readonly Configuration _configuration;
    private readonly IServiceManager _serviceManager;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public OrderController(IServiceManager service, IWebHostEnvironment webHostEnvironment, IOptions<Configuration> configuration)
    {
        _serviceManager = service;
        _webHostEnvironment = webHostEnvironment;
        _configuration = configuration.Value;
    }

    [HttpGet("page")]
    public async Task<IActionResult> GetOrders([FromQuery] OrderParameters orderParameters)
    {
        PagedList<OrderDto> orders = await _serviceManager.OrderService.GetOrdersAsync(orderParameters);

		return Ok(orders);
	}

    [HttpGet("invoice/{invoiceId}")]
    public async Task<IActionResult> GetInvoice(string invoiceId)
    {
		string filePath = Path.Combine(_webHostEnvironment.WebRootPath, _configuration.FilePathConfiguration.Document, $"{invoiceId}.pdf");
		string fileLink = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/{filePath.Replace(@"\", "/")}";

		return Ok(fileLink);
	}
}
