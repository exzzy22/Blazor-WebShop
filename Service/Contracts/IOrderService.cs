namespace Service.Contracts;

public interface IOrderService
{
	Task<PagedList<OrderDto>> GetOrdersAsync(OrderParameters orderParameters);
}
