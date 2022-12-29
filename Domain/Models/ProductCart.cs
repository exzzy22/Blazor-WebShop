namespace Domain.Models;

public class ProductCart
{
	public int Id { get; set; }
	public int ProductId { get; set; }
	public int Quantity { get; set; } = 1;

	public virtual Product Product { get; set; } = null!;
}
