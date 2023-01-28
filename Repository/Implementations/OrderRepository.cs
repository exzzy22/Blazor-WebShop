using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository.Implementations;

internal sealed class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    private readonly RepositoryContext _repositoryContext;

    public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext) => _repositoryContext = repositoryContext;

	public async Task<Order> GetOrderAsync(int orderId, bool trackChanges) => 
        await FindByCondition(o => o.Id == orderId,trackChanges)
        .Include(o => o.BillingAddress)
		.Include(o => o.ShippingAddress)
		.FirstAsync();

    public async Task<PagedList<Order>> GetOrdersAsync(OrderParameters orderParameters, bool trackChanges)
    {
        List<Order> orders = await _repositoryContext.Orders.FilterOrders(orderParameters.Filter)
            .Sort(orderParameters.OrderBy)
            .ToListAsync();

        return PagedList<Order>.ToPagedList(orders,orderParameters.PageNumber,orderParameters.PageSize);
    }
}
