namespace Shared.DataTransferObjects;

public class CategoryDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public virtual ICollection<ProductForCreationDto>? Products { get; set; }
}
