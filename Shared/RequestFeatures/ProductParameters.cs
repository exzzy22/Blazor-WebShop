namespace Shared.RequestFeatures;

public class ProductParameters : RequestParameters
{
	public ProductFilter Filter { get; set; } = new();
}
