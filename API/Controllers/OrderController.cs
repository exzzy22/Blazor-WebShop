using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shared.RequestFeatures;
using System.Text.Json;

namespace API.Controllers;

[Route("api/order")]
[ApiController]
[AllowAnonymous]
public class OrderController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public OrderController(IServiceManager service)
    {
        _serviceManager = service;
    }

    [HttpGet("page")]
    public async Task<IActionResult> GetOrders([FromQuery] OrderParameters orderParameters)
    {
        PagedList<OrderDto> orders = await _serviceManager.OrderService.GetOrdersAsync(orderParameters);

		return Ok(orders);
	}
}
