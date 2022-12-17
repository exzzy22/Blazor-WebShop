namespace Shared.DataTransferObjects;

public class ProductForCreationDto
{
    public int? Id { get; set; } = null;
    public string Name { get; set; } = null!;
    public int Discount { get; set; }
    public int InStock { get; set; }
    public int Sold { get; set; }
    public int CategoryId { get; set; }
	public string SelectedSpecification { get; set; } = null!;
    public AttributesDto Attributes { get; set; } = null!;
    public List<ImageForCreationDto> Images { get; set; } = null!;
    public List<PriceForCreationDto> Prices { get; set; } = null!;
}
