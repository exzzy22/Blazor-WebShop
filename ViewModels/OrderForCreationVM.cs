using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public class OrderForCreationVM
{
	[ValidateComplexType]
	public AddressVM BillingAddress { get; set; } = new();
	[ValidateComplexType]
	public AddressVM ShippingAddress { get; set; } = new();
	[Required]
	[Range(typeof(bool), "true", "true",ErrorMessage = "You must agree to the Terms and Conditions")]
	public bool TosAccepted { get; set; } = false;
	public string? Note { get; set; }
	public int CartId { get; set; }
	public string CurrencyISO { get; set; } = null!;
}
