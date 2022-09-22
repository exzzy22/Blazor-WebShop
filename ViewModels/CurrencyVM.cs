namespace ViewModels;

public class CurrencyVM
{
    public int Id { get; init; }
    public string ISO4217 { get; init; } = null!;
    public string Symbol { get; init; } = null!;
}
