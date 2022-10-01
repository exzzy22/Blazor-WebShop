using System.Net.Http;

namespace ApiServices;

public interface IApiService
{
    Task<ProductVM> GetProduct(int productId);
    Task<List<ProductVM>> GetProductsAsync();
    Task<CarouselVM> GetCarouselTopSelling(int numberOfCategories, int numberOfProducts);
    Task<List<AdminVM>> GetAdmins();
    Task<bool> CreateAdmin(AdminForCreationVM admin);
    Task<bool> DeleteAdmin(int adminId);
    Task<bool> UpdateAdmin(AdminVM admin);

    bool AuthenticationHeaderExits();
    void SetAuthenticationHeader(string jwtToken);
}