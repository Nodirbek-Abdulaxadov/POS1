using BLL.Helpers;
using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace BLL.Dtos.WarehouseDtos;

public class AddWarehouseDto
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;


    public static explicit operator Warehouse(AddWarehouseDto v)
        => new Warehouse()
        {
            Name = v.Name,
            AddedDate = LocalTime.GetUtc5Time(),
            ModifiedDate = LocalTime.GetUtc5Time(),
            IsDeleted = false
        };
}
