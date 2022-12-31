using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ViewModels;

public class PriceVM
{
    [Required]
    public float Value { get; set; }
    [Required]
    public CurrencyVM Currency { get; set; } = null!;
}
