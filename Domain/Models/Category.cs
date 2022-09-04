namespace Domain.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<SubCategory> SubCategories { get; set; }
}
