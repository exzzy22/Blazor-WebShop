namespace Domain.Models;

public class Address
{
	public int Id { get; set; }
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Street { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string City { get; set; } = null!;
	public string Country { get; set; } = null!;
	public string ZipCode { get; set; } = null!;
	public string Tel { get; set; } = null!;
	public int? BillingOrderId { get; set; }
	public int? ShippingOrderId { get; set; }

	public virtual Order? BillingOrder { get; set; }
	public virtual Order? ShippingOrder { get; set; }
}

