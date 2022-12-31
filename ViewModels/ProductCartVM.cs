using System.Globalization;

namespace ViewModels;

public class ProductCartVM
{
	public int Id { get; set; }
	public int ProductId { get; set; }
	public int Quantity { get; set; } = 1;

	public virtual ProductVM Product { get; set; } = null!;
}
