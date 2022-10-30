namespace API.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IServiceManager _service;

    public UserController(IServiceManager service) => _service = service;


    [HttpPost("new")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> NewUser(UserForRegistrationDto userForRegistration)
    {
        var result = await _service.AuthenticationService.RegisterUserAsync(userForRegistration);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        return StatusCode(201);
    }
}
