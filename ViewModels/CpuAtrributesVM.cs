using ViewModels.ValidationAttributes;

namespace ViewModels;

public class CpuAtrributesVM : AttributesVM
{
    [Required]
	[NameForDisplay("CPU Socket")]
	public string Socket { get; set; } = null!;
    [Required]
	[NameForDisplay("# of CPU Cores")]
	public int CoreCount { get; set; }
    [Required]
	[NameForDisplay("# of Threads")]
	public int ThreadCount { get; set; }
    [Required]
	[NameForDisplay("L3 Cache")]
	[ValueAdditionText("MB")]
	public int CacheL3 { get; set; }
    [Required]
	[NameForDisplay("Base Clock")]
	[ValueAdditionText("GHz")]
	public float BaseClockCpu { get; set; }
    [Required]
	[NameForDisplay("Max. Boost Clock")]
	[ValueAdditionText("GHz")]
	public float BoostClockCpu { get; set; }
    [Required]
	[NameForDisplay("Default TDP")]
	[ValueAdditionText("W")]
	public int TDP { get; set; }
    [Required]
	[NameForDisplay("Integrated Graphic")]
	public string Graphics { get; set; } = null!;
}
