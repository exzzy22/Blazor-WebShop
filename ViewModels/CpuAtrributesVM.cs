using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public class CpuAtrributesVM : AttributesVM
{
    [Required]
    public string Socket { get; set; } = null!;
    [Required]
    public int CoreCount { get; set; }
    [Required]
    public int ThreadCount { get; set; }
    [Required]
    public int CacheL3 { get; set; }
    [Required]
    public float BaseClockCpu { get; set; }
    [Required]
    public float BoostClockCpu { get; set; }
    [Required]
    public int TDP { get; set; }
    [Required]
    public string Graphics { get; set; } = null!;
}
