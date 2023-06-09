﻿using DataLayer.Entities;

namespace BLL.Dtos.WarehouseDtos;

public class WarehouseViewDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime AddedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public static explicit operator WarehouseViewDto(Warehouse v)
        => new WarehouseViewDto()
        {
            Id = v.Id,
            Name = v.Name,
            AddedDate = v.AddedDate,
            ModifiedDate = v.ModifiedDate
        };
}
