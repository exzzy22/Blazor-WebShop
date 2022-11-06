using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public abstract class AttributesVM
{
    [Required]
    public string Manufacturer { get; set; } = null!;
}
