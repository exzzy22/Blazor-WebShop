using System.ComponentModel.DataAnnotations;
using ViewModels.ValidationAttributes;

namespace ViewModels;

public class UserForAuthenticationVM
{
	[Required]
	[EmailAddress]
	public string Email { get; set; } = null!;
	[Required]
	public string Password { get; set; } = null!;
}
