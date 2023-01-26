using Shared.RequestFeatures;

namespace Repository.Contracts;

public interface IOrderRepository
{
	void Create(Order order);
	Task<Order> GetOrderAsync(int orderId, bool trackChanges);
	Task<PagedList<Order>> GetOrdersAsync(OrderParameters orderParameters, bool trackChanges);
}
