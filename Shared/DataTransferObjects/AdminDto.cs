namespace Shared.DataTransferObjects;

public record AdminDto()
{
    public int Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; init; } = null!;
}
