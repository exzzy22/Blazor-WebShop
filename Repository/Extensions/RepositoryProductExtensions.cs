namespace Repository.Extensions;

internal static class RepositoryProductExtensions
{
	public static IQueryable<Product> FilterProducts(this IQueryable<Product> products, ProductFilter filter)
	{
		if (!string.IsNullOrWhiteSpace(filter.Keywords))
		{
			string lowerCaseTerm = filter.Keywords.Trim().ToLower();
			products = products.Where(e => e.Name.ToLower().Contains(lowerCaseTerm) || e.ShortName.ToLower().Contains(lowerCaseTerm));
		}

		if (filter.CategoryId.HasValue)
		{
			products = products.Where(e => e.CategoryId.Equals(filter.CategoryId.Value));
		}

		return products;
	}

	public static IQueryable<Product> Sort(this IQueryable<Product> orders, string orderByQueryString)
	{
		if (string.IsNullOrWhiteSpace(orderByQueryString))
			return orders.OrderByDescending(e => e.Sold);

		string orderQuery = OrderByQueryBuilder.CreateOrderQuery<Product>(orderByQueryString);

		if (string.IsNullOrWhiteSpace(orderQuery))
			return orders.OrderByDescending(e => e.Sold);

		return orders.OrderBy(orderQuery);
	}
}
