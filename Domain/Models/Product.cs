using System.Diagnostics.Metrics;

namespace Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Discount { get; set; } = 0;
    public int InStock { get; set; } = 0;
    public int Sold { get; set; } = 0;
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
    public virtual Attributes Attributes { get; set; } = null!;
    public virtual ICollection<Price> Prices { get; set; } = null!;
    public virtual ICollection<Picture> Pictures { get; set; } = null!;
}
