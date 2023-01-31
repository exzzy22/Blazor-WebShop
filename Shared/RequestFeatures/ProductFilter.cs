namespace Shared.RequestFeatures;

public class ProductFilter
{
	public string? Keywords { get; set; }
	public List<int> CategoryId { get; set; } = new ();
	public List<string> Manufacturer { get; set; } = new();
	public double? MinPrice { get; set; }
	public double? MaxPrice { get; set; }
	public int CurrencyId { get; set; }
}
