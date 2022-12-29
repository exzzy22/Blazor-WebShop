namespace Shared.DataTransferObjects
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; init; } = null!;
        [Required(ErrorMessage = "Password name is required")]
        public string Password { get; init; } = null!;
    }
}