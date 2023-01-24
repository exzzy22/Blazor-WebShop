namespace Repository.Implementations;

internal sealed class ProductRepository : RepositoryBase<Product> , IProductRepository
{
    private readonly RepositoryContext _repositoryContext;
    public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext) => _repositoryContext = repositoryContext;

    public async Task<Product?> GetProductAsync(int id, bool trackChanges, bool ignoreAutoIncludes = false) =>
        !ignoreAutoIncludes ?
        await FindByCondition(p => p.Id.Equals(id), trackChanges)
        .Include(p => p.Category)
        .Include(p => p.Attributes)
        .Include(p => p.Images)
        .FirstOrDefaultAsync()
        :
        await FindByCondition(p => p.Id.Equals(id), trackChanges)
        .Include(p => p.Category)
        .Include(p => p.Attributes)
        .Include(p => p.Images)
		.IgnoreAutoIncludes()
		.FirstOrDefaultAsync();


	public async Task<IEnumerable<Product>> GetProductsAsync() => await FindAll(false)
        .Include(p => p.Category)
        .Include(p => p.Attributes)
        .Include(p => p.Images)
        .ToListAsync();

	public async Task<IEnumerable<Product>> GetProductsAsync<T>(Expression<Func<Product, T>> orderBy, int numberOfProducts) =>
        await FindAll(false)
	    .Include(p => p.Category)
	    .Include(p => p.Attributes)
	    .Include(p => p.Images)
        .OrderBy(orderBy)
        .Take(numberOfProducts)
	    .ToListAsync();
}
