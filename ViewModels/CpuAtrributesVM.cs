using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public class CpuAtrributesVM : AttributesVM
{
    [Required]
    public string? Model { get; set; } = null!;
    [Required]
    public string? Socket { get; set; } = null!;
    [Required]
    public int? CoreCount { get; set; } = null!;
    [Required]
    public int? ThreadCount { get; set; } = null!;
    [Required]
    public int? CacheL3 { get; set; } = null!;
    [Required]
    public float? BaseClock { get; set; } = null!;
    [Required]
    public float? BoostClock { get; set; } = null!;
    [Required]
    public int? TDP { get; set; } = null!;
    [Required]
    public string? Graphics { get; set; } = null!;
}
