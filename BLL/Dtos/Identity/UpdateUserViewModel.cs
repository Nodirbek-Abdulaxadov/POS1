using System.ComponentModel.DataAnnotations;

namespace BLL.Dtos.Identity;

public class UpdateUserViewModel
{
    public string Id { get; set; } = string.Empty;
    [Required]
    public string FullName { get; set; } = string.Empty;
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
}