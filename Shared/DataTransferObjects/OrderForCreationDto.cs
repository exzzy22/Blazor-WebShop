namespace Shared.DataTransferObjects;

public record OrderForCreationDto
{
    public AddressDto BillingAddress { get; init; } = null!;
    public AddressDto ShippingAddress { get; init; } = null!;
    public bool TosAccepted { get; init; }
    public string? Note { get; init; }
    public int CartId { get; init; }
    public string CurrencyISO { get; init; } = null!;
}
