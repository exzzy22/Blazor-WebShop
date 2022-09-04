using System.Net.Http.Headers;
using ViewModels;

namespace ApiServices;

public interface IApiService
{
    Task<List<ProductVM>> GetProductsAsync();

    bool AuthenticationHeaderExits();
    void SetAuthenticationHeader(string jwtToken);
}