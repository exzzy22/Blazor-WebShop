using System.Net.Http;

namespace ApiServices;

public interface IApiService
{
    #region Products
    Task<ProductVM> GetProduct(int productId);
    Task<ProductForCreationVM> GetProductForUpdate(int productId);
    Task<bool> AddProduct(ProductForCreationVM product);
    Task<bool> DeleteProduct(int productId);
    Task<bool> UpdateProduct(ProductVM product);
    Task<bool> UpdateProduct(ProductForCreationVM product);
    Task<List<ProductVM>> GetProducts();
    Task<IEnumerable<ProductCarouselVM>> GetCarouselTopSelling(int numberOfProducts);
    Task<bool> DeleteImage(string image);
    Task<bool> DeleteImage(List<string> images);
    Task<List<ImageForTableVM>> GetUnusedImages();
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

    #region Currency
    Task<bool> AddCurrency(CurrencyDto currency);
    Task<List<CurrencyVM>> GetCurrencies();
    Task<bool> DeleteCurrency(int currencyId);
    Task<bool> UpdateCurrency(CurrencyVM currency);
    #endregion

    #region Cart
    Task<CartVM> AddProductToCart(int productId, int cartId, int quantity);
	Task<CartVM> RemoveProductFromCart(int productId, int cartId);
    Task<CartVM> GetCart(int cartId);
	#endregion
	bool AuthenticationHeaderExits();
    void SetAuthenticationHeader(string jwtToken);
}