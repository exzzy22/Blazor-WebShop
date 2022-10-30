namespace Shared.DataTransferObjects;

public record UserDto
{
    public int Id { get; init; }
    [Required]
    public string FirstName { get; init; } = null!;
    [Required]
    public string LastName { get; init; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; init; } = null!;
    public string? PhoneNumber { get; set; }
}
