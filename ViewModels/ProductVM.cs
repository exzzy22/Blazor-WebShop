using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public class ProductVM
{
    public string Name { get; init; } = null!;
    public int Discount { get; init; }
    public int InStock { get; init; }
    public int Sold { get; init; }
    public int CategoryId { get; init; }
    public AttributesVM Attributes { get; init; } = null!;

    public virtual ICollection<PriceVM> Prices { get; init; } = null!;
}