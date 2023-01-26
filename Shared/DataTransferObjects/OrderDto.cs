using Domain.Models;

namespace Shared.DataTransferObjects;

public record OrderDto
{
    public int Id { get; init; }
    public int CartId { get; init; }
    public int? UserId { get; init; }
    public int BillingAddressId { get; init; }
    public int ShippingAddressId { get; init; }
    public string StripeId { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string CurrencyISO4217 { get; init; } = null!;
    public double Amount { get; init; }
    public Guid SessionId { get; init; }
    public OrderStatus Status { get; init; } = OrderStatus.Created;
    public DateTime CratedDate { get; init; }


    public virtual AddressDto BillingAddress { get; init; } = null!;
    public virtual AddressDto ShippingAddress { get; init; } = null!;
}
