using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public class PriceForCreationVM
{
    public int? Id { get; set; }
    [Required]
    public float? Value { get; set; }
    [Required]
    public int? CurrencyId { get; set; }
}
