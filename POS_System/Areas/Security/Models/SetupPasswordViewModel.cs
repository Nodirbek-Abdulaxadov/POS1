using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Areas.Security.Models;

public class SetupPasswordViewModel
{
    [Required]
    [PasswordPropertyText]
    public string Password { get; set; } = string.Empty;
    [Required]
    [PasswordPropertyText]
    public string ConfirmPassword { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}