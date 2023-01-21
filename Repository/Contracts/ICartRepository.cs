namespace Repository.Contracts;

public interface ICartRepository
{
	void Create(Cart cart);
	Task<Cart?> GetCartAsync(int id, bool trackChanges);
	Task<Cart?> GetUserCartAsync(int userId, bool trackChanges);
	void Update(Cart cart);
	void Delete(Cart cart);
}
