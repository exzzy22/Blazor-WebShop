namespace ApiServices;

public interface IApiService
{
    Task<List<ProductVM>> GetProductsAsync();
    Task<CarouselVM> GetCarouselTopSelling(int numberOfCategories, int numberOfProducts);

    bool AuthenticationHeaderExits();
    void SetAuthenticationHeader(string jwtToken);
}