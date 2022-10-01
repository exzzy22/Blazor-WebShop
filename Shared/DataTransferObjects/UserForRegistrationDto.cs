namespace Shared.DataTransferObjects
{
    public record UserForRegistrationDto
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? UserName { get; init; }
        public string Password { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string? PhoneNumber { get; init; }
    }
}