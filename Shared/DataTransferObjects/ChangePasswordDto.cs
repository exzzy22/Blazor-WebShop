namespace Shared.DataTransferObjects;

public class ChangePasswordDto
{
	[Required]
	public string OldPassword { get; init; } = null!;
	[Required]
	public string NewPassword { get; init; } = null!;
}
