namespace Repository.Contracts;

public interface IProductRepository
{
    void Create(Product product);
    Task<Product?> GetProductAsync(int id, bool trackChanges, bool ignoreAutoIncludes = false);
    void Update(Product product);
    void Delete(Product product);
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<IEnumerable<Product>> GetProductsForCategoryAsync(int categoryId, int numberOfProducts);
    Task<IEnumerable<Product>> GetProductsAsync<T>(Expression<Func<Product, T>> orderBy, int numberOfProducts);
    Task<ProductPagedList<Product>> GetProductsAsync(ProductParameters productParameters);
}
