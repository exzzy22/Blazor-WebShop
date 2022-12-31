namespace ViewModels;

public class CartVM
{
	public int Id { get; set; }
	public List<ProductCartVM> Products { get; set; } = new();

	public double GetCartTotal(CurrencyVM currency)
	{
		double sum = 0;

		foreach (ProductCartVM product in Products)
		{
			sum += (product.Quantity * product.Product.GetPrice(currency));
		}

		return sum;
	}
}
