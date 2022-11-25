using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public class GpuAtrributesVM : AttributesVM
{
    [Required]
    public string Brand { get; set; } = null!;
    [Required]
    public string Interface { get; set; } = null!;
    [Required]
    public float CoreClockGpu { get; set; }
    [Required]
    public float BoostClockGpu { get; set; }
    [Required]
    public string StreamProcessors { get; set; } = null!;
    [Required]
    public int Memory { get; set; }
    [Required]
    public int MemoryInterface { get; set; }
    [Required]
    public string MemoryType { get; set; } = null!;
    [Required]
    public string HDMI { get; set; } = null!;
    [Required]
    public string DisplayPort { get; set; } = null!;
    [Required]
    public string Cooler { get; set; } = null!;
    [Required]
    public string RecommendedPSU { get; set; } = null!;
    [Required]
    public string PowerConnector { get; set; } = null!;
    [Required]
    public int MaxGPULength { get; set; }
    [Required]
    public string SlotWidth { get; set; } = null!;
}
