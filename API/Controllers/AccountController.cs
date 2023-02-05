namespace API.Controllers
{
    [Route("api/account")]
    [ApiController]
    [AllowAnonymous]// Fix rights later
    // Fix rights later
    // Fix rights later
    // Fix rights later
    public class AccountController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AccountController(IServiceManager service) => _service = service;

        [HttpPost("user/new")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
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

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _service.AuthenticationService.ValidateUserAsync(user))
                return Unauthorized();

            var tokenDto = await _service.AuthenticationService.CreateTokenAsync(populateExp: true);

            return Ok(tokenDto);
        }

		[HttpGet("user/logged")]
        [Authorize]
		public async Task<IActionResult> GeetLoggedUser()
		{
            UserDto user = await _service.AuthenticationService.GetUserInfo(User);

			return Ok(user);
		}

		[HttpPost("user/changePassword")]
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[Authorize]
		public async Task<IActionResult> ChangePassword(ChangePasswordDto changePassword)
		{
			IdentityResult result = await _service.AuthenticationService.ChangePasswordAsync(changePassword, User);

			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.TryAddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}

			return Ok();
		}

		[HttpGet("admin")]
        public async Task<IActionResult> GetAdmins()
        {
            var admins = await _service.AuthenticationService.GetUsersInRoleAsync(DatabaseConstants.RoleConstants.Administrator.Name);

            return Ok(admins);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.AuthenticationService.GetUsersInRoleAsync( DatabaseConstants.RoleConstants.User.Name);

            return Ok(users);
        }

        [HttpPost("admin/new")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateAdmin(AdminForCreationDto admin)
        {
            var result = await _service.AuthenticationService.CreateAdminAsync(admin);

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

        [HttpPost("admin/edit")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAdmin(AdminDto admin)
        {
            var result = await _service.AuthenticationService.UpdateAdminAsync(admin);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPost("user/edit")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateUser(UserDto user)
        {
            var result = await _service.AuthenticationService.UpdateUserAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpDelete("admin/delete/{adminId}")]
        public async Task<IActionResult> DeleteAdmin(int adminId)
        {
            var result = await _service.AuthenticationService.DeleteAdminAsync(adminId);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(204);
        }
    }
}