namespace Service.Contracts;

public interface IPaymentService
{
    Task<string> CreatePaymentUrl(OrderForCreationDto order);
    Task<bool> ValidatePayment(int orderId, string sessionId);
}
