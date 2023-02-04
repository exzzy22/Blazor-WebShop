namespace ViewModels;

public class SubmitReviewVM
{
	public string? Name { get; set; }
	[Required]
	public string Description { get; set; } = null!;
	[Required]
	[EmailAddress]
	public string Email { get; set; } = null!;
	[Required]
	[Range(1, 5, ErrorMessage = "Please select rating")]
	public int StarRating { get; set; }
	public int ProductId { get; set; }
}
