using ViewModels.ValidationAttributes;

namespace ViewModels;

public class ChangePasswordVM
{
	[Required]
	[Password]
	public string OldPassword { get; set; } = null!;
	[Required]
	[Password]
	[Compare(nameof(OldPassword), ErrorMessage = "Passwords don't match.")]
	public string OldPassword2 { get; set; } = null!;
	[Required]
	[Password]
	public string NewPassword { get; set; } = null!;
}
