namespace Shared.DataTransferObjects;

public record ProductForCreationDto()
{
    public string Name { get; init; } = null!;
    [Range(10, 100, ErrorMessage = "Value must be between 0 and 100")]
    public int Discount { get; init; } = 0;
    public int InStock { get; init; } = 0;
    public int Sold { get; init; } = 0;
    public int CategoryId { get; init; }
    public string DerivedType { get; init; } = null!;
    public string AttributesJSON { get; init; } = null!;

    public virtual ICollection<PriceForCreationDto> Prices { get; init; } = null!;


}
