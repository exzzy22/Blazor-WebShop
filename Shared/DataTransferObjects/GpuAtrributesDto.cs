using Domain.Models;

namespace Shared.DataTransferObjects;

public class GpuAtrributesDto : Attributes
{
    public string Brand { get; set; } = null!;
    public string Interface { get; set; } = null!;
    public float CoreClockGpu { get; set; }
    public float BoostClockGpu { get; set; }
    public string StreamProcessors { get; set; } = null!;
    public int Memory { get; set; }
    public int MemoryInterface { get; set; }
    public string MemoryType { get; set; } = null!;
    public string HDMI { get; set; } = null!;
    public string DisplayPort { get; set; } = null!;
    public string Cooler { get; set; } = null!;
    public string RecommendedPSU { get; set; } = null!;
    public string PowerConnector { get; set; } = null!;
    public int MaxGPULength { get; set; }
    public string SlotWidth { get; set; } = null!;
}
