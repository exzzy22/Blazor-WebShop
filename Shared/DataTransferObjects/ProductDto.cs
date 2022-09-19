namespace Shared.DataTransferObjects;

public record ProductDto
{
    public string Name { get; init; } = null!;
    public int Discount { get; init; }
    public int InStock { get; init; }
    public int Sold { get; init; }
    public int CategoryId { get; init; }
    public AttributesDto Attributes { get; init; } = null!;

    public virtual ICollection<PriceDto> Prices { get; init; } = null!;
}
