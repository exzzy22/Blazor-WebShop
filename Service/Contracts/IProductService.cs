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
}
