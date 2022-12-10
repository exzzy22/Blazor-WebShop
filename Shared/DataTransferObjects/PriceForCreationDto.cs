namespace Shared.DataTransferObjects;

public record PriceForCreationDto
{
    public int? Id { get; set; }
    public float Value { get; init; }
    public int CurrencyId { get; init; }
}
