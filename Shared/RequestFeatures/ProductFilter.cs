namespace Shared.RequestFeatures;

public class ProductFilter
{
	public string? Keywords { get; set; }
	public List<int> CategoryId { get; set; } = new ();
	public List<string> Manufacturer { get; set; } = new();
}
