namespace Domain.Models;

public class SubCategory
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual Category Category { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
