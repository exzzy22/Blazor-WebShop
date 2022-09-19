using Domain.Models;
using Repository.Base;
using Repository.Contracts;

namespace Repository.Implementations;

internal sealed class ProductRepository : RepositoryBase<Product> , IProductRepository
{
    public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext) {}

    public async Task<Product?> GetProductAsync(int id, bool trackChanges) => await FindByCondition(p => p.Id.Equals(id), trackChanges).FirstOrDefaultAsync();

    public async Task<IEnumerable<Product>> GetProductsAsync() => await FindAll(false)
        .Include(p => p.Category)
        .Include(p => p.Attributes)
        .ToListAsync();
}
