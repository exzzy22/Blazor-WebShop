namespace Shared.DataTransferObjects;

public record ProductCarouselDto
{
	public int Id { get; init; }
	public string Name { get; init; } = null!;
    public string ShortName { get; set; } = null!;
    public int Discount { get; init; } = 0;
    public int InStock { get; init; } = 0;
    public int Sold { get; init; } = 0;
    public int CategoryId { get; init; }
	public int AvgStarRating { get; set; }
	public string Image { get; set; } = null!;

	public CategoryDto Category { get; set; } = null!;
	public ICollection<PriceDto> Prices { get; init; } = null!;
}
