namespace ViewModels;

public class ProductCarouselVM
{
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public int Discount { get; set; } = 0;
    public bool IsDiscounted { get => Discount > 0; }
    public int InStock { get; set; } = 0;
    public int Sold { get; set; } = 0;
    public int CategoryId { get; set; }
    public string Image { get; set; } = null!;

    public CategoryVM Category { get; set; } = null!;
    public List<PriceVM> Prices { get; set; } = null!;

	public double CalculateDiscountedPrice(float price) => price - (price * (Discount / 100.0));

}
