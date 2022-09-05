namespace Shared.DataTransferObjects;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<SubCategoryDto> SubCategories { get; set; }
}
