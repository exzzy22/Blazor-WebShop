namespace Shared.DataTransferObjects;

public record ProductCarouselDto
{
    public string Name { get; init; } = null!;
    [Range(10, 100, ErrorMessage = "Value must be between 0 and 100")]
    public int Discount { get; init; } = 0;
    public int InStock { get; init; } = 0;
    public int Sold { get; init; } = 0;
    public int CategoryId { get; init; }

    public virtual ICollection<PriceDto> Prices { get; init; } = null!;
}
