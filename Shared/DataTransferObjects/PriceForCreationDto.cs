namespace Shared.DataTransferObjects;

public record PriceForCreationDto
{
    public float Value { get; init; }
    public int CurrencyId { get; init; }
}
