using Domain.Models;
using Repository.Base;
using Repository.Contracts;

namespace Repository.Implementations;

internal sealed class ProductRepository : RepositoryBase<Product> , IProductRepository
{
    public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext) {}

    public void DeleteProduct(Product product) => Delete(product);

    public async Task<Product> GetProductAsync(int id, bool trackChanges) => await FindByCondition(p => p.Id.Equals(id), trackChanges).FirstOrDefaultAsync();

    public async Task<IEnumerable<Product>> GetProductsAsync() => await FindAll(false).ToListAsync();

    public void UpdateProduct(Product product) => Update(product);
}
