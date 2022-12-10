using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using ViewModels.Static;
using ViewModels.ValidationAttributes;

namespace ViewModels;

public class ProductForCreationVM
{
    public int? Id { get; set; } = null;

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public int? Discount { get; set; }

    [Required]
    public int? InStock { get; set; }

    [Required]
    public int? CategoryId { get; set; }
	[Required]
	public int Sold { get; set; } = 0;

	[Required]
    public AttributesVM? Attributes { get; set; } = null!;

    [CollectionCount<PriceForCreationVM>("Product must contain at least one price", 1)]
    public List<PriceForCreationVM> Prices { get; set; } = new();

    [ProductImages]
    public ICollection<PictureForCreationVM> Pictures { get; set; } = null!;

    public ImmutableList<string> Specifications { get; } = AttributesDictionary.Attributes.ToImmutableList();

    [Required]
    public string? SelectedSpecification { get; set; }

    [Range(typeof(bool), "true", "true")]
    public bool IsFormValid { get; set; } = false;

}
