namespace ViewModels;

public class SubscribeNewsLetterVM
{
	[Required]
	[EmailAddress]
	public string Email { get; set; } = null!;
}
