using Domain;

namespace Shared.RequestFeatures;

public class OrderFilter
{
    public int? UserId { get; set; }
    public OrderStatus? Status { get; set; }
    public string? ISO4217 { get; set; }
    public string? Email { get; set; }
}
