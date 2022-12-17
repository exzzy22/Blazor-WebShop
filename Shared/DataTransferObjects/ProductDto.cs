namespace Shared.DataTransferObjects;

public record ProductDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public int Discount { get; init; }
    public int InStock { get; init; }
    public int Sold { get; init; }
    public int CategoryId { get; init; }
    public AttributesDto Attributes { get; init; } = null!;
    public ICollection<ImageForCreationDto> Pictures { get; set; } = null!;
    public ICollection<PriceDto> Prices { get; init; } = null!;
}
