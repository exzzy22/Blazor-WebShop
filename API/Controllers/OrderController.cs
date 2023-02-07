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
	[Authorize]
	public async Task<IActionResult> GetOrders([FromQuery] OrderParameters orderParameters)
    {
        PagedList<OrderDto> orders = await _serviceManager.OrderService.GetOrdersAsync(orderParameters);

		return Ok(orders);
	}

    [HttpGet("invoice/{invoiceId}")]
    public async Task<IActionResult> GetInvoice(string invoiceId)
    {
		FileStream invoice = System.IO.File.OpenRead(_webHostEnvironment.WebRootPath + _configuration.FilePathConfiguration.Document + invoiceId + ".pdf");

		return File(invoice, "application/pdf");
	}
}
