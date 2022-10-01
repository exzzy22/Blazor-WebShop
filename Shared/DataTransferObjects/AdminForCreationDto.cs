namespace Shared.DataTransferObjects;

public record AdminForCreationDto()
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    [Required]
    [EmailAddress]
    public string Email { get; init; } = null!;
    [Required]
    public string Password { get; init; } = null!;


}
