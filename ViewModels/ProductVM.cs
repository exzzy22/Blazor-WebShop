using System.Globalization;

namespace ViewModels;

public class ProductVM
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
	public string ShortName { get; set; } = null!;
	public int Discount { get; set; }
	public bool IsDiscounted { get => Discount > 0; }
	public int InStock { get; set; }
    public int Sold { get; set; }
    public int CategoryId { get; set; }
    public AttributesVM Attributes { get; set; } = null!;
	public List<PriceVM> Prices { get; set; } = null!;
	public List<ImageVM> Images { get; set; } = null!;

    public double GetPrice(CurrencyVM currency)
    { 
        if(Discount > 0)
            return CalculateDiscountedPrice(currency);

		return Prices.First(p => p.Currency.Id.Equals(currency.Id)).Value;
	}

	public double CalculateDiscountedPrice(CurrencyVM currency) => GetPriceForCurrency(currency).Value - (GetPriceForCurrency(currency).Value * (Discount / 100.0));
	PriceVM GetPriceForCurrency(CurrencyVM currency) => Prices.First(p => p.Currency.Id.Equals(currency.Id));


}