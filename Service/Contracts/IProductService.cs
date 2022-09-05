using System.Linq.Expressions;

namespace Service.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    public Task<IEnumerable<CarouselDto>> GetCarouselProductsAsync<T>(Expression<Func<Product, T>> orderBy, int numberOfCategories, int numberOfProducts);
}
