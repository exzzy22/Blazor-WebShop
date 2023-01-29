using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public class UserVM
{
    public int Id { get; set; }
	[Required]
	public string FirstName { get; set; } = null!;
	[Required]
	public string LastName { get; set; } = null!;
	[Required]
	[EmailAddress]
	public string Email { get; set; } = null!;
	public string RefreshToken { get; set; } = null!;
	public string Street { get; set; } = null!;
	public string City { get; set; } = null!;
	public string Country { get; set; } = null!;
	public string ZipCode { get; set; } = null!;
	public string PhoneNumber { get; set; } = null!;
}
