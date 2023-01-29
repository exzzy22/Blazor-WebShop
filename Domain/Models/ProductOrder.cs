namespace Domain.Models;

public class ProductOrder
{
	public int Id { get; set; }
	public int Quantity { get; set; }
	public double Price { get; set; }
	public int Discount { get; set; }
    public double TotalPrice { get; set; }
    public string CurrencyISO4217 { get; set; } = null!;
	public string CurrencySymbol { get; set; } = null!;
	public string Name { get; set; } = null!;
	public string ShortName { get; set; } = null!;
}
