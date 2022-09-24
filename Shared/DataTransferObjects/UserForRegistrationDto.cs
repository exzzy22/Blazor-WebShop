namespace Shared.DataTransferObjects
{
    public record UserForRegistrationDto
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string? PhoneNumber { get; init; }
        public ICollection<string> Roles { get; init; } = null!;
    }
}