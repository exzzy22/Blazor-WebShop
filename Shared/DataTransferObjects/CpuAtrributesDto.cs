namespace Shared.DataTransferObjects;

public record CpuAtrributesDto : AttributesDto
{
    public string Socket { get; set; } = null!;
    public int CoreCount { get; set; }
    public int ThreadCount { get; set; }
    public int CacheL3 { get; set; }
    public float BaseClockCpu { get; set; }
    public float BoostClockCpu { get; set; }
    public int TDP { get; set; }
    public string Graphics { get; set; } = null!;
}