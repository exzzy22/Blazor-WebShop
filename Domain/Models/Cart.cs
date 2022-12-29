namespace Domain.Models;

public class Cart
{
	public int Id { get; set; }
	public int? UserId { get; set; }

	public virtual ICollection<ProductCart> Products { get; set; } = null!;
}
