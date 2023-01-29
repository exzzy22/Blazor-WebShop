using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public class CategoryVM
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;

    public  List<ProductVM>? Products { get; set; }
}
