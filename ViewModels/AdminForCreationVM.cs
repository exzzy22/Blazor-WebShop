using System.ComponentModel.DataAnnotations;
using ViewModels.ValidationAttributes;

namespace ViewModels;

public class AdminForCreationVM
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    [Password]
    public string Password { get; set; } = null!;
    [Required]
    [Compare(nameof(Password))]
    public string Password2 { get; set; } = null!;
}
