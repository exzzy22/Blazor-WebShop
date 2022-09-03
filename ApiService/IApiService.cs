using System.Net.Http.Headers;

namespace ApiService;

public interface IApiService
{
    public bool AuthenticationHeaderExits();
    public void SetAuthenticationHeader(string jwtToken);
}