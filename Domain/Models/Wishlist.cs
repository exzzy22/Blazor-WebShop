namespace Domain.Models;

public class Wishlist
{
	public int Id { get; set; }
	public int? UserId { get; set; }

	public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
