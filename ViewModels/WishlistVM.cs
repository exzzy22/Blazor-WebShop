namespace ViewModels;

public class WishlistVM
{
	public int Id { get; init; }
	public int? UserId { get; init; }

	public List<ProductVM> Products { get; init; } = new();
}
