using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public class CategoryVM
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;

    public virtual ICollection<ProductVM>? Products { get; set; }
}
