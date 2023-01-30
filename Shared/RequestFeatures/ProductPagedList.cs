namespace Shared.RequestFeatures;

public class ProductPagedList<T> : PagedList<T>
{
	public new ProductResponseMetaData MetaData { get; set; }
	public ProductPagedList()
	{

	}
	public ProductPagedList(List<T> items, int count, int pageNumber, int pageSize, IDictionary<int, int> categoryCount, IDictionary<string,int> manufacturerCount)
	{
		MetaData = new ProductResponseMetaData
		{
			TotalCount = count,
			PageSize = pageSize,
			CurrentPage = pageNumber,
			TotalPages = (int)Math.Ceiling(count / (double)pageSize),
			CategoryCount = categoryCount,
			ManufacturerCount = manufacturerCount
		};
		Items = items;
	}

	public static ProductPagedList<T> ToProductPagedList(IEnumerable<T> source, int pageNumber, int pageSize, IDictionary<int, int> categoryCount, IDictionary<string, int> manufacturerCount)
	{
		int count = source.Count();
		List<T> items = source
		  .Skip((pageNumber - 1) * pageSize)
		  .Take(pageSize)
		  .ToList();

		return new ProductPagedList<T>(items, count, pageNumber, pageSize, categoryCount, manufacturerCount);
	}
}
