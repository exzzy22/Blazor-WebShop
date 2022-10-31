namespace ViewModels;

public class PriceVM
{
    public float Value { get; set; }
    public int CurrencyId { get; set; }

    public virtual CurrencyVM Currency { get; set; } = null!;
}
