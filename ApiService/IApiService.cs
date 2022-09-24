namespace ApiServices;

public interface IApiService
{
    Task<ProductVM> GetProduct(int productId);
    Task<List<ProductVM>> GetProductsAsync();
    Task<CarouselVM> GetCarouselTopSelling(int numberOfCategories, int numberOfProducts);

    bool AuthenticationHeaderExits();
    void SetAuthenticationHeader(string jwtToken);
}