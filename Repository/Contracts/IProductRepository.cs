namespace Repository.Contracts;

public interface IProductRepository
{
    void Create(Product product);
    Task<Product?> GetProductAsync(int id, bool trackChanges);
    void Update(Product product);
    void Delete(Product product);
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<IEnumerable<Product>> GetProductsAsync<T>(Expression<Func<Product, T>> orderBy, int numberOfProducts);

}
