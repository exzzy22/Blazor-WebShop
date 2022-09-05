namespace Shared.DataTransferObjects;

public class SubCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<ProductDto> Products { get; set; }
}
