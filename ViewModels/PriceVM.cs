namespace ViewModels;

public class PriceVM
{
    public float Value { get; init; }
    public int CurrencyId { get; set; }

    public virtual CurrencyVM Currency { get; init; } = null!;
}
