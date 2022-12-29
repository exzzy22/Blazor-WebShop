using System.ComponentModel.DataAnnotations;
using ViewModels.ValidationAttributes;

namespace ViewModels;

public class UserForRegistrationVM
{
	[Required]
	public string FirstName { get; set; } = null!;
	[Required]
	public string LastName { get; set; } = null!;
	[Required]
	[EmailAddress]
	public string Email { get; set; } = null!;
	[Required]
	[EmailAddress]
	[Compare(nameof(Email), ErrorMessage = "Emails don't match.")]
	public string Email2 { get; set; } = null!;
	public string Address { get; set; } = null!;
	public string City { get; set; } = null!;
	public string Country { get; set; } = null!;
	public string ZipCode { get; set; } = null!;
	[Phone]
	public string Tel { get; set; } = null!;
	[Required]
	[Password]
	public string Password { get; set; } = null!;
    [Required]
    [Password]
    [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
    public string Password2 { get; set; } = null!;
}
