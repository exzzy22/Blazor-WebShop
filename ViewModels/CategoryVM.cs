namespace ViewModels;

public class CategoryVM
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<ProductVM>? Products { get; set; }
}
