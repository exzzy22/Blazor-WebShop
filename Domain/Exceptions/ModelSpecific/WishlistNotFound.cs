namespace Domain.Exceptions.ModelSpecific;

public class WishlistNotFound : NotFoundException
{
	public WishlistNotFound(int id) : base($"Wishlist {id} not found")
	{
	}
}
