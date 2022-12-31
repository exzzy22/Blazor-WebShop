using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public class OrderVM
{
	[ValidateComplexType]
	public AdressVM BillingAdress { get; set; } = new();
	[ValidateComplexType]
	public AdressVM ShippingAddress { get; set; } = new();
	public bool TosAccepted { get; set; } = false;
	public string? Note { get; set; }
}
