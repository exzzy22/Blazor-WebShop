namespace Service.Contracts;

public interface IProductService
{
    Task<ProductDto> GetProductAsync(int productId);
    Task AddProductAsync(ProductDto product);
    Task DeleteProductAsync(int productId);
    Task UpdateProductAsync(ProductDto product);
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    Task<CarouselDto> GetCarouselProductsAsync<T>(Expression<Func<Product, T>> orderBy, int numberOfCategories, int numberOfProducts);
}
