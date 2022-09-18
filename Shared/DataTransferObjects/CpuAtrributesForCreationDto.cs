namespace Shared.DataTransferObjects;

public record CpuAtrributesForCreationDto : AttributesForCreationDto
{
    public string Model { get; init; } = null!;
    public string Socket { get; init; } = null!;
    public int CoreCount { get; init; }
    public int ThreadCount { get; init; }
    public int CacheL3 { get; init; }
    public float BaseClock { get; init; }
    public float BoostClock { get; init; }
    public int TDP { get; init; }
    public string Graphics { get; init; } = null!;
}