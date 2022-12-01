namespace Shared.DataTransferObjects
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; init; } = null!;
        [Required(ErrorMessage = "Password name is required")]
        public string Password { get; init; } = null!;
    }
}