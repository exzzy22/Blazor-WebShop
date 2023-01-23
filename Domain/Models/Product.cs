using System.Diagnostics.Metrics;

namespace Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public int Discount { get; set; } = 0;
    public int InStock { get; set; } = 0;
    public int Sold { get; set; } = 0;
    public int CategoryId { get; set; }
    public string SelectedSpecification { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
    public virtual Attributes Attributes { get; set; } = null!;
    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
	public virtual ICollection<Price> Prices { get; set; } = null!;
    public virtual ICollection<Image> Images { get; set; } = null!;
}
