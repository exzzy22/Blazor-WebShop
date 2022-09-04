using System.Diagnostics.Metrics;

namespace Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    [Range(10, 100, ErrorMessage = "Value must be between 0 and 100")]
    public int Discount { get; set; } = 0;
    public int InStock { get; set; } = 0;
    public int Sold { get; set; } = 0;

    public virtual SubCategory SubCategory { get; set; }

}
