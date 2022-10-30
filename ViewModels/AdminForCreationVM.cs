using System.ComponentModel.DataAnnotations;
using ViewModels.ValidationAttributes;

namespace ViewModels;

public class AdminForCreationVM
{
    [Required(ErrorMessage = "The First Name field is required.")]
    public string FirstName { get; set; } = string.Empty;
    [Required(ErrorMessage = "The Last Name field is required.")]
    public string LastName { get; set; } = string.Empty;
    [Required(ErrorMessage = "The Email field is required.")]
    [EmailAddress(ErrorMessage = "The Email format is wrong.")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "The Password field is required.")]
    [Password]
    public string Password { get; set; } = null!;
    [Required(ErrorMessage = "The Password field is required.")]
    [Compare(nameof(Password))]
    public string Password2 { get; set; } = null!;
}
