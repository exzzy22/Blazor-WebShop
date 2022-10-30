namespace ApiServices;

public interface IApiService
{
    #region Products
    Task<ProductVM> GetProduct(int productId);
    Task<List<ProductVM>> GetProductsAsync();
    Task<CarouselVM> GetCarouselTopSelling(int numberOfCategories, int numberOfProducts);
    #endregion

    #region Accounts
    Task<List<AdminVM>> GetAdmins();
    Task<List<UserVM>> GetUsers();
    Task<bool> CreateAdmin(AdminForCreationVM admin);
    Task<bool> DeleteAdmin(int adminId);
    Task<bool> UpdateAdmin(AdminVM admin);
    #endregion

    #region Categories
    Task<bool> AddCategory(CategoryVM category);
    Task<List<CategoryVM>> GetCategories();
    Task<bool> DeleteCategory(int categoryId);
    Task<bool> UpdateCategory(CategoryVM category);
    #endregion

    bool AuthenticationHeaderExits();
    void SetAuthenticationHeader(string jwtToken);
}