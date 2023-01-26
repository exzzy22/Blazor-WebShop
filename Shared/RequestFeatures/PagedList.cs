namespace Shared.RequestFeatures;

public class PagedList<T>
{
    public MetaData MetaData { get; set; }
    public List<T> Items { get; set; }
    public PagedList()
    {

    }
    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        MetaData = new MetaData
        {
            TotalCount = count,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };
        Items = items;
    }
    public PagedList(List<T> items, MetaData metaData)
    {
        MetaData= metaData;
		Items = items;
	}
	public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        int count = source.Count();
        List<T> items = source
          .Skip((pageNumber - 1) * pageSize)
          .Take(pageSize)
          .ToList();

        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}