namespace Repository.Extensions;

internal static class RepositoryOrderExtensions
{
    public static IQueryable<Order> FilterOrders(this IQueryable<Order> orders, OrderFilter filter)
    {
        if (filter.UserId.HasValue)
        {
            orders = orders.Where(e => e.UserId.Equals(filter.UserId.Value));
        }

        if (filter.Status.HasValue)
        {
            orders = orders.Where(e => e.Status.Equals(filter.Status.Value));
        }

        if (!string.IsNullOrEmpty(filter.ISO4217))
        {
            orders = orders.Where(e => e.CurrencyISO4217.Equals(filter.ISO4217));
        }

        if (!string.IsNullOrEmpty(filter.Email))
        {
            orders = orders.Where(e => e.Email.Equals(filter.Email));
        }

        return orders;
    }

    public static IQueryable<Order> Sort(this IQueryable<Order> orders, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return orders.OrderByDescending(e => e.CratedDate);

        string orderQuery = OrderByQueryBuilder.CreateOrderQuery<Order>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return orders.OrderByDescending(e => e.CratedDate);

        return orders.OrderBy(orderQuery);
    }
}
