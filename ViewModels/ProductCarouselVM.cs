using System.Globalization;

namespace ViewModels;

public class ProductCarouselVM
{
	public int Id { get; set; }
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

	public double CalculateDiscountedPrice(CurrencyVM currency) => GetPrice(currency).Value - (GetPrice(currency).Value * (Discount / 100.0));
    public PriceVM GetPrice(CurrencyVM currency) => Prices.First(p => p.Currency.Id.Equals(currency.Id));
}
