using System.Linq.Expressions;

namespace Service.Contracts;

public interface IProductService
{
    Task<ProductDto> GetProduct(int productId);
    Task AddProduct(ProductDto product);
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    public Task<CarouselDto> GetCarouselProductsAsync<T>(Expression<Func<Product, T>> orderBy, int numberOfCategories, int numberOfProducts);
}
