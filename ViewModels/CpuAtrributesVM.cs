namespace ViewModels;

public class CpuAtrributesVM : AttributesVM
{
    public string Model { get; set; } = null!;
    public string Socket { get; set; } = null!;
    public int CoreCount { get; set; }
    public int ThreadCount { get; set; }
    public int CacheL3 { get; set; }
    public float BaseClock { get; set; }
    public float BoostClock { get; set; }
    public int TDP { get; set; }
    public string Graphics { get; set; } = null!;
}
