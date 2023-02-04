namespace Shared.DataTransferObjects;

public class SubmitReviewDto
{
	public string? Name { get; init; }
	public string Description { get; init; } = null!;
	public string Email { get; init; } = null!;
	public int StarRating { get; init; }
	public int ProductId { get; init; }
}
