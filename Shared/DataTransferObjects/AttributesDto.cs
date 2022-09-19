using System.Text.Json.Serialization;

namespace Shared.DataTransferObjects;

[JsonDerivedType(typeof(CpuAtrributesDto), 1)]
public abstract record AttributesDto
{
    public string Manufacturer { get; init; } = null!;
}
