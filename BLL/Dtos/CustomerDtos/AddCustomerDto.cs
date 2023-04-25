using BLL.Helpers;
using DataLayer.Entities.Selling;

namespace BLL.Dtos.CustomerDtos;

public class AddCustomerDto
{
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public static explicit operator Customer(AddCustomerDto v)
        => new Customer()
        {
            FullName = v.FullName,
            PhoneNumber = v.PhoneNumber,
            AddedDate = LocalTime.GetUtc5Time(),
            ModifiedDate = LocalTime.GetUtc5Time(),
            IsDeleted = false
        };
}
