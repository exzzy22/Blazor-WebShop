namespace Service.Contracts;

public interface IProductService
{
    Task<ProductDto> GetProductAsync(int productId);
    Task<ProductForCreationDto> GetProductForUpdateAsync(int productId);
    Task AddProductAsync(ProductForCreationDto product);
    Task DeleteProductAsync(int productId);
    Task UpdateProductAsync(ProductForCreationDto product);
    Task UpdateProductAsync(ProductDto product);
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    Task<IEnumerable<ProductCarouselDto>> GetCarouselProductsAsync<T>(Expression<Func<Product, T>> orderBy, int numberOfProducts);
    void DeleteImage(string name);
    void DeleteImage(List<string> names);
    Task<IEnumerable<ImageForTableDto>> GetListOfUnusedImages();

    Task<CartDto> AddProductToCart(int productId, int cartId, int quantity, int? userId = null);
	Task<CartDto> RemoveProductFromCart(int productId, int cartId);
	Task<CartDto> GetCart(int cartId);
    Task<CartDto> GetUserCart(int userId);
    Task<CartDto> ClearCart(int cartId);
    Task<CartDto> JoinCartToUser(int cartId, int userId);

	Task<WishlistDto> AddRemoveFromWishlist(int wishlistId, int productId, int? userId = null);
    Task<WishlistDto> GetWishlist(int id);
    Task<WishlistDto> GetUserWishlist(int userId);
    Task<WishlistDto> JoinWishlistToUser(int wishlistId, int userId);

}
