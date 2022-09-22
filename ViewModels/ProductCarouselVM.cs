namespace ViewModels;

public class ProductCarouselVM
{
    public string Name { get; init; } = null!;
    public int Discount { get; init; } = 0;
    public int InStock { get; init; } = 0;
    public int Sold { get; init; } = 0;
    public int CategoryId { get; init; }

    public virtual ICollection<PriceVM> Prices { get; init; } = null!;
}
