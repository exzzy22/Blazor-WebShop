namespace Service.Contracts;

public interface IPaymentService
{
    Task<string> CreatePaymentUrl(OrderDto order);
}
