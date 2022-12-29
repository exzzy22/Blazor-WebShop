namespace ViewModels;

public class CartVM
{
	public int Id { get; set; }
	public List<ProductCartVM> Products { get; set; } = new();
}
