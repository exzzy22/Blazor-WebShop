using Shared;

namespace ViewModels;

public class OrderVM
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int? UserId { get; set; }
    public int BillingAddressId { get; set; }
    public int ShippingAddressId { get; set; }
    public string StripeId { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string CurrencyISO4217 { get; set; } = null!;
    public double Amount { get; set; }
    public Guid SessionId { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Created;
    public DateTime CratedDate { get; set; }


    public virtual AddressVM BillingAddress { get; set; } = null!;
    public virtual AddressVM ShippingAddress { get; set; } = null!;
}
