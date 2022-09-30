using System.Net.Http;

namespace ApiServices;

public interface IApiService
{
    Task<ProductVM> GetProduct(int productId);
    Task<List<ProductVM>> GetProductsAsync();
    Task<CarouselVM> GetCarouselTopSelling(int numberOfCategories, int numberOfProducts);
    Task<List<RoleVM>> GetRoles();
    Task<bool> CreateRole(RoleDto role);
    Task<bool> RemoveRole(int roleId);
    Task<bool> UpdateRole(RoleDto role);

    bool AuthenticationHeaderExits();
    void SetAuthenticationHeader(string jwtToken);
}