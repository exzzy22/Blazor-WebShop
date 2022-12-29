namespace Repository.Implementations;

internal sealed class CartRepository : RepositoryBase<Cart>, ICartRepository
{
	private readonly RepositoryContext _repositoryContext;
	public CartRepository(RepositoryContext repositoryContext) : base(repositoryContext) => _repositoryContext = repositoryContext;

	public async Task<Cart?> GetCartAsync(int id, bool trackChanges) =>
		await FindByCondition(c => c.Id.Equals(id), trackChanges)
		.Include(c => c.Products)
		.ThenInclude(p => p.Product)
		.ThenInclude( p => p.Images)
		.FirstOrDefaultAsync();
}
