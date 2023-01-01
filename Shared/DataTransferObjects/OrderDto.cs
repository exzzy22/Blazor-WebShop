namespace Shared.DataTransferObjects;

public record OrderDto
{
    public AdressDto BillingAddress { get; init; } = null!;
    public AdressDto ShippingAddress { get; init; } = null!;
    public bool TosAccepted { get; init; }
    public string? Note { get; init; }
    public int CartId { get; init; }
    public string CurrencyISO { get; init; } = null!;
}
