using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public class ProductForCreationVM
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int? Discount { get; set; }
    [Required]
    public int? InStock { get; set; }
    [Required]
    public int? CategoryId { get; set; }
    public AttributesVM Attributes { get; set; } = null!;
    public List<PriceVM> Prices { get; set; } = new();
    public ImmutableList<string> Specifications { get; } = new List<string>() { "CPU Specifications" }.ToImmutableList();
    [Required]
    public string? SelectedSpecification { get; set; }

}
