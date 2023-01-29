namespace Shared.DataTransferObjects
{
    public record UserForRegistrationDto
    {
		public string FirstName { get; init; } = null!;
		public string LastName { get; init; } = null!;
		public string Email { get; init; } = null!;
		public string? Street { get; init; }
		public string? City { get; init; }
		public string? Country { get; init; }
		public string? ZipCode { get; init; }
		public string? PhoneNumber { get; init; }
		public string Password { get; init; } = null!;
	}
}