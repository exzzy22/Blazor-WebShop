namespace Domain.Models;

public class Attributes
{
    public int Id { get; set; }
    public string Manufacturer { get; set; } = null!;
    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
}   
