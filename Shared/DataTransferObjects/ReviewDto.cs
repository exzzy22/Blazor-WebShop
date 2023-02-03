namespace Shared.DataTransferObjects;

public record ReviewDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string Description { get; init; } = null!;
    public string Email { get; init; } = null!;
    public int StarRating { get; init; }
    public DateTime CreatedDate { get; init; }
}
