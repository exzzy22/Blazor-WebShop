using System.ComponentModel.DataAnnotations;
using ViewModels.ValidationAttributes;

namespace ViewModels;

public class GpuAtrributesVM : AttributesVM
{
    [Required]
    [NameForDisplay("Brand")]
    public string Brand { get; set; } = null!;
    [Required]
    [NameForDisplay("Interface")]
    public string Interface { get; set; } = null!;
    [Required]
    [NameForDisplay("Core Clock")]
    [ValueAdditionText("MHz")]
    public float CoreClockGpu { get; set; }
    [Required]
    [NameForDisplay("Boost Clock")]
    [ValueAdditionText("MHz")]
    public float BoostClockGpu { get; set; }
    [Required]
    [NameForDisplay("Stream Processors")]
    public string StreamProcessors { get; set; } = null!;
    [Required]
    [NameForDisplay("Memory Size")]
    [ValueAdditionText("GB")]
    public int Memory { get; set; }
    [Required]
    [NameForDisplay("Memory Interface")]
    [ValueAdditionText("Bit")]
    public int MemoryInterface { get; set; }
    [Required]
    [NameForDisplay("Memory Type")]
    public string MemoryType { get; set; } = null!;
    [Required]
    [NameForDisplay("HDMI")]
    public string HDMI { get; set; } = null!;
    [Required]
    [NameForDisplay("DisplayPort")]
    public string DisplayPort { get; set; } = null!;
    [Required]
    [NameForDisplay("Cooler")]
    public string Cooler { get; set; } = null!;
    [Required]
    [NameForDisplay("MRecommended PSU Wattage")]
    [ValueAdditionText("W")]
    public string RecommendedPSU { get; set; } = null!;
    [Required]
    [NameForDisplay("Power Connector")]
    public string PowerConnector { get; set; } = null!;
    [Required]
    [NameForDisplay("Max GPU Length")]
    [ValueAdditionText("mm")]
    public int MaxGPULength { get; set; }
    [Required]
    [NameForDisplay("Slot Width")]
    public string SlotWidth { get; set; } = null!;
}
