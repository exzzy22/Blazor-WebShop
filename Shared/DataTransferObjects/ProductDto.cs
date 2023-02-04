using Domain.Models;

namespace Shared.DataTransferObjects;

public record ProductDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string ShortName { get; init; } = null!;
    public int Discount { get; init; }
    public int InStock { get; init; }
    public int Sold { get; init; }
    public int CategoryId { get; init; }
	public string? Description { get; init; }
    public int AvgStarRating { get; set; }
    public AttributesDto Attributes { get; init; } = null!;
    public List<ImageDto> Images { get; set; } = null!;
    public List<PriceDto> Prices { get; init; } = null!;
    public List<Review> Reviews { get; init; } = null!;
}
