namespace Repository.Contracts;

public interface IWishlistRepository
{
	Task<Wishlist?> GetById(int id, bool trackChanges);
    Task<Wishlist?> GetUserWishList(int userId, bool trackChanges);
    void Delete(Wishlist wishlist);
	void Create(Wishlist wishlist);
	void Update(Wishlist wishlist);
}
