namespace Repository.Extensions;

internal static class RepositoryProductExtensions
{
	public static IQueryable<Product> FilterProducts(this IQueryable<Product> products, ProductFilter filter)
	{
		if (!string.IsNullOrWhiteSpace(filter.Keywords))
		{
			string lowerCaseTerm = filter.Keywords.Trim().ToLower();
			products = products.Where(p => p.Name.ToLower().Contains(lowerCaseTerm) || p.ShortName.ToLower().Contains(lowerCaseTerm));
		}

		if (filter.CategoryId.Count>0 && filter.CategoryId.Any())
		{
			products = products.Where(p => filter.CategoryId.Contains(p.CategoryId));
		}

		if (filter.Manufacturer.Count > 0 && filter.Manufacturer.Any())
		{
			products = products.Where(p => filter.Manufacturer.Contains(p.Attributes.Manufacturer));
		}

		if (filter.MinPrice.HasValue)
		{
			products = products.Where(p => p.Prices.First( price => price.CurrencyId == filter.CurrencyId).Value > filter.MinPrice);
		}

		if (filter.MaxPrice.HasValue)
		{
			products = products.Where(p => p.Prices.First(price => price.CurrencyId == filter.CurrencyId).Value < filter.MaxPrice);
		}

		return products;
	}

	public static IQueryable<Product> Sort(this IQueryable<Product> products, string orderByQueryString)
	{
		if (string.IsNullOrWhiteSpace(orderByQueryString))
			return products.OrderByDescending(e => e.Sold);

		string orderQuery = OrderByQueryBuilder.CreateOrderQuery<Product>(orderByQueryString);

		if (string.IsNullOrWhiteSpace(orderQuery))
			return products.OrderByDescending(e => e.Sold);

		return products.OrderBy(orderQuery);
	}

	public static IQueryable<Product> SortByPrice(this IQueryable<Product> products, string orderByQueryString, int currencyId)
	{
		bool desc = orderByQueryString.EndsWith(" desc");

		return desc 
			? 
			products.OrderByDescending(e => e.Prices.First(p => p.CurrencyId == currencyId).Value) 
			: 
			products.OrderBy(e => e.Prices.First(p => p.CurrencyId == currencyId).Value);
	}
}
