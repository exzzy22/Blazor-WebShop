namespace ApiServices;

public interface IApiService
{
    Task<List<ProductVM>> GetProductsAsync();
    Task<List<CarouselVM>> GetCarouselTopSelling(int numberOfCategories, int numberOfProducts);

    bool AuthenticationHeaderExits();
    void SetAuthenticationHeader(string jwtToken);
}