namespace Domain.Exceptions.ModelSpecific;

public class CartNotFound : NotFoundException
{
	public CartNotFound(int id) : base($"Cart {id} not found")
	{
	}
}
