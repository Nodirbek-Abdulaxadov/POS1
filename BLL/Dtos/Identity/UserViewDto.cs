using Core;

namespace BLL.Dtos.Identity;

public class UserViewDto
{
    public string Id { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;

    public static explicit operator UserViewDto(User v)
        => new UserViewDto()
        {
            Id = v.Id,
            FullName = v.FullName,
            PhoneNumber = v.PhoneNumber ?? ""
        };
}
