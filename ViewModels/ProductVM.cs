namespace ViewModels;

public class ProductVM
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
	public string ShortName { get; set; } = null!;
	public int Discount { get; set; }
    public int InStock { get; set; }
    public int Sold { get; set; }
    public int CategoryId { get; set; }
    public AttributesVM Attributes { get; set; } = null!;
    public virtual ICollection<PriceVM> Prices { get; set; } = null!;
}