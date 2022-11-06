namespace Shared.DataTransferObjects;

public class CurrencyForCreationDto
{
    public string ISO4217 { get; init; } = null!;
    public string Symbol { get; init; } = null!;
}
