namespace Shared.DataTransferObjects;

public record ProductForCreationDto
{
    public string Name { get; init; } = null!;
    public int Discount { get; init; }
    public int InStock { get; init; }
    public int Sold { get; init; }
    public int CategoryId { get; init; }
    public AttributesDto Attributes { get; init; } = null!;
    public ICollection<PictureForCreationDto> Pictures { get; set; } = null!;
    public ICollection<PriceForCreationDto> Prices { get; init; } = null!;
}
