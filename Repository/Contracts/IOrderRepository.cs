namespace Repository.Contracts;

public interface IOrderRepository
{
	void Create(Order order);
	Task<Order> GetOrderAsync(int orderId, bool trackChanges);
}
