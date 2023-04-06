using System.ComponentModel.DataAnnotations;

namespace BLL.Dtos.Identity;

public class RegisterUserViewModel
{
    [Required]
    public string FullName { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    public string UserRole { get; set; } = string.Empty;
}