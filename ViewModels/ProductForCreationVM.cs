using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using ViewModels.Static;

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
    public List<PriceForCreationVM> Prices { get; set; } = new();
    public ICollection<PictureForCreationVM> Pictures { get; set; } = null!;
    public ImmutableList<string> Specifications { get; } = AttributesDictionary.Attributes.ToImmutableList();
    [Required]
    public string? SelectedSpecification { get; set; }

}
