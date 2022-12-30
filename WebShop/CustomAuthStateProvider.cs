using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebShop;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
	private readonly IJSRuntime _jSRuntime;
	public CustomAuthStateProvider(IJSRuntime jSRuntime)
	{
		_jSRuntime = jSRuntime;
	}

	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		string token = await _jSRuntime.InvokeAsync<string>("readCookie", "jwtToken");

		ClaimsIdentity identity = new ();

		if (!string.IsNullOrEmpty(token))
		{
			JwtSecurityTokenHandler tokenHandler = new ();
			JwtSecurityToken parsedJwt = tokenHandler.ReadJwtToken(token);


			if (parsedJwt != null && parsedJwt?.ValidTo.Date.ToLocalTime() > DateTime.Now)
			{
				identity = new ClaimsIdentity(parsedJwt.Claims, "jwt");
			}
		}

		ClaimsPrincipal user = new (identity);
		AuthenticationState state = new AuthenticationState(user);

		NotifyAuthenticationStateChanged(Task.FromResult(state));

		return state;
	}
}
