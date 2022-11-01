using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public class PriceVM
{
    [Required]
    public float? Value { get; set; }
    //public int? CurrencyId { get; set; }
    [Required]
    public CurrencyVM? Currency { get; set; }
}
