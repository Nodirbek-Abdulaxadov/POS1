using BLL.Helpers;
using DataLayer.Entities;

namespace BLL.Dtos.WarehouseDtos;

public class WarehouseUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime AddedDate { get; set; }

    public static explicit operator Warehouse(WarehouseUpdateDto v)
        => new Warehouse()
        {
            Id = v.Id,
            Name = v.Name,
            IsDeleted = false,
            AddedDate = v.AddedDate,
            ModifiedDate = LocalTime.GetUtc5Time()
        };
}