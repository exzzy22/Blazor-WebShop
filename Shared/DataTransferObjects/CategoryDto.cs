namespace Shared.DataTransferObjects;

public class CategoryDto
{
    public int Id { get; init; }
    [Required]
    public string Name { get; init; } = null!;
    public virtual ICollection<ProductForCreationDto>? Products { get; set; }
}
