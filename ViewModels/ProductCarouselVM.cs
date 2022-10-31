namespace ViewModels;

public class ProductCarouselVM
{
    public string Name { get; set; } = null!;
    public int Discount { get; set; } = 0;
    public int InStock { get; set; } = 0;
    public int Sold { get; set; } = 0;
    public int CategoryId { get; set; }

    public virtual ICollection<PriceVM> Prices { get; set; } = null!;
}
