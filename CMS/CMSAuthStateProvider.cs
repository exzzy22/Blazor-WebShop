﻿namespace CMS;

public class CMSAuthStateProvider : AuthenticationStateProvider
{
    private readonly IJSRuntime _jSRuntime;
    private readonly IApiService _apiService;
    private readonly UserState _userState;
    public CMSAuthStateProvider(IJSRuntime jSRuntime, IApiService apiService, UserState userState)
    {
        _jSRuntime = jSRuntime;
        _apiService = apiService;
        _userState = userState;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string token = await _jSRuntime.InvokeAsync<string>("readCookie", "jwtToken");

        ClaimsIdentity identity = new();

        if (!string.IsNullOrEmpty(token))
        {
            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken parsedJwt = tokenHandler.ReadJwtToken(token);

            if (parsedJwt != null && parsedJwt?.ValidTo.Date.ToLocalTime() > DateTime.Now)
            {
                identity = new ClaimsIdentity(parsedJwt.Claims, "jwt");
            }
        }

        ClaimsPrincipal user = new(identity);
        AuthenticationState state = new AuthenticationState(user);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        if (state.User is not null && state.User.Identity is not null && state.User.Identity.IsAuthenticated)
        {
            _apiService.SetAuthenticationHeader(token);
            _userState.User = await _apiService.GetLoggedAdmin();
        }
        else
        {
            _apiService.RemoveAuthenticationHeader();
            _userState.User = null;
        }
        return state;
    }
}
