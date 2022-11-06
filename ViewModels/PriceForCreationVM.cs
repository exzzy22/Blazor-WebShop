using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public class PriceForCreationVM
{
    [Required]
    public float? Value { get; set; }
    [Required]
    public int? CurrencyId { get; set; }
}
