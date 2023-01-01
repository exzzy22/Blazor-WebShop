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
    public string PhoneNumber { get; init; } = null!;
	public string RefreshToken { get; init; } = null!;
	public string Address { get; init; } = null!;
	public string City { get; init; } = null!;
	public string Country { get; init; } = null!;
	public string ZipCode { get; init; } = null!;
	public string Tel { get; init; } = null!;
}
