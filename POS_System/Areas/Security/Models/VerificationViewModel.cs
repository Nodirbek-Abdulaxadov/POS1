using System.ComponentModel.DataAnnotations;

namespace API.Areas.Security.Models;

public class VerificationViewModel
{
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    public int Code { get; set; }
}