using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/payment")]
[ApiController]
[AllowAnonymous]// Fix rights later
public class PaymentController : ControllerBase
{
    private readonly IServiceManager _service;

    public PaymentController(IServiceManager service) => _service = service;

    [HttpPost("create")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreatePayment(OrderDto order)
    {
        string paymentUrl = await _service.PaymentService.CreatePaymentUrl(order);

        return Ok(paymentUrl);
    }

    [HttpPost("validate/{orderId}/{sessionId}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> ValidatePayment(int orderId, string sessionId)
    {
        bool result = await _service.PaymentService.ValidatePayment(orderId, sessionId);

        if(result)
            return Ok();

        return BadRequest();
    }

}
