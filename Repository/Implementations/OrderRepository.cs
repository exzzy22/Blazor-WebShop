namespace Repository.Implementations;

internal sealed class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
	public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{
	}

	public async Task<Order> GetOrderAsync(int orderId, bool trackChanges) => await FindByCondition(o => o.Id == orderId,trackChanges).FirstAsync();
}
