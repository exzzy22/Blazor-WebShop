namespace Domain.Models;

public class Currency
{
    public int Id { get; set; }
    public string ISO4217 { get; set; } = null!;
    public string Symbol { get; set; } = null!;
}
