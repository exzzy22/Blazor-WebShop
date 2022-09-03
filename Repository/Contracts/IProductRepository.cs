using Domain.Models;

namespace Repository.Contracts;

public interface IProductRepository
{
    Task<Product> GetProductAsync(int id, bool trackChanges);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    Task<IEnumerable<Product>> GetProductsAsync();
}
