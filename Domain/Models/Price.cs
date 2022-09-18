namespace Domain.Models;

public class Price
{
    public int Id { get; set; }
    public float Value { get; set; }
    public int ProductId { get; set; }
    public int CurrencyId { get; set; }

    public virtual Currency Currency { get; set; } = null!;
}
