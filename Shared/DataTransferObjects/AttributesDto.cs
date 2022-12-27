using System.Text.Json.Serialization;

namespace Shared.DataTransferObjects;

[JsonDerivedType(typeof(CpuAtrributesDto), 1)]
[JsonDerivedType(typeof(GpuAtrributesDto), 2)]

public abstract record AttributesDto
{
    public string Manufacturer { get; init; } = null!;
    public string Model { get; init; } = null!;
}
