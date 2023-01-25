namespace Service.Contracts;

public interface IPaymentService
{
    Task<string> CreatePaymentUrl(OrderDto order);
    Task<bool> ValidatePayment(int orderId, string sessionId);
}
