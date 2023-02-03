using Domain.Models;
using Shared.RequestFeatures;
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
    Task<ProductPagedList<ProductVM>> GetProducts(ProductParameters productParameters);
	Task<IEnumerable<ProductCarouselVM>> GetCarouselTopSelling(int numberOfProducts);
    Task<bool> DeleteImage(string image);
    Task<bool> DeleteImage(List<string> images);
    Task<List<ImageForTableVM>> GetUnusedImages();
    Task<PagedList<ReviewVM>> GetReviews(ReviewParameters reviewParameters);
    #endregion

    #region Accounts
    Task<List<AdminVM>> GetAdmins();
    Task<List<UserVM>> GetUsers();
    Task<bool> CreateAdmin(AdminForCreationVM admin);
    Task<bool> DeleteAdmin(int adminId);
    Task<bool> UpdateAdmin(AdminVM admin);
    Task<bool> UpdateUser(UserVM user);
    Task<bool> Register(UserForRegistrationVM userForRegistration);
	Task<(bool,TokenVM?)> Login(UserForAuthenticationVM userForAuthentication);
    Task<UserVM> GetLoggedUser();
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
    Task<CartVM> AddProductToCart(int productId, int cartId, int quantity, int? userId = null);
	Task<CartVM> RemoveProductFromCart(int productId, int cartId);
    Task<CartVM> GetCart(int cartId);
    Task<CartVM> GetUserCart(int userId);
    Task<CartVM> ClearCart(int cartId);
    Task<CartVM> JoinCartToUser(int cartId, int userId);
    #endregion

    #region Wishlist
    Task<WishlistVM> AddRemoveFromWishlist(int wishlistId, int productId, int? userId = null);
	Task<WishlistVM> GetWishlist(int id);
    Task<WishlistVM> GetUserWishlist(int userId);
    Task<WishlistVM> JoinWishlistToUser(int wishlistId, int userId);
	#endregion

	#region Payment
	Task<string> CreatePayment(OrderForCreationVM order);
    Task<bool> ValidatePayment(int orderId, string sessionId);
    #endregion

    #region Order
    Task<PagedList<OrderVM>> GetOrders(OrderParameters orderParameters);
    Task<string> GetInvoice(string invoiceId);
    #endregion
    bool AuthenticationHeaderExits();
    void SetAuthenticationHeader(string jwtToken);
    void RemoveAuthenticationHeader();
}