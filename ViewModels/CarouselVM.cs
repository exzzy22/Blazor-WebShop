namespace ViewModels;

public class CarouselVM
{
    public List<CategoryVM> Categories { get; set; } = new();
    public List<ProductCarouselVM> Products { get; set; } = new();
}
