namespace Shared.DataTransferObjects;

public record PriceDto
{
    public float Value { get; init; }
    public int CurrencyId { get; set; }
}
