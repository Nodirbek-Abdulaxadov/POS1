using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Areas.Security.Models;

public class PhoneNumberViewModel
{
    [Required]
    [MinLength(9)]
    [StringLength(13)]
    [DisplayName("Telefon raqam")]
    public string PhoneNumber { get; set; } = string.Empty;
}