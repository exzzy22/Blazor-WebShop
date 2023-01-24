namespace Repository.Implementations;

public class WishlistRepository : RepositoryBase<Wishlist>, IWishlistRepository
{
	private readonly RepositoryContext _repositoryContext;
	public WishlistRepository(RepositoryContext repositoryContext) : base(repositoryContext) => _repositoryContext = repositoryContext;

	public async Task<Wishlist> GetById(int id, bool trackChanges) => 
		await FindByCondition(w => w.Id == id, trackChanges)
		.Include(w => w.Products)
		.ThenInclude(p => p.Images)
		.FirstAsync();
}
