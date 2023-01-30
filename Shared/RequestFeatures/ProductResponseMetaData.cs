namespace Shared.RequestFeatures;

public class ProductResponseMetaData : MetaData
{
	public IDictionary<int,int> CategoryCount { get; set; }
	public IDictionary<string, int> ManufacturerCount { get; set; }
}
