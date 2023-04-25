using BLL.Helpers;
using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace BLL.Dtos.WarehouseItemDtos;

public class AddWarehouseItemDto
{
    [Required]
    public int Quantity { get; set; }
    [Required]
    public DateOnly BroughtDate { get; set; }
    [Required]
    public decimal IncomingPrice { get; set; }
    [Required]
    public decimal SellingPrice { get; set; }

    [Required]
    public int ProductId { get; set; }
    [Required]
    public string AdminId { get; set; } = string.Empty;
    [Required]
    public int WarehouseId { get; set; }

    public static explicit operator WarehouseItem(AddWarehouseItemDto v)
        => new WarehouseItem()
        {
            Quantity = v.Quantity,
            SellingPrice = v.SellingPrice,
            ProductId = v.ProductId,
            AdminId = v.AdminId,
            WarehouseId = v.WarehouseId,
            BroughtDate = v.BroughtDate.ToString(),
            IncomingPrice = v.IncomingPrice,
            IsDeleted = false,
            AddedDate = LocalTime.GetUtc5Time(),
            ModifiedDate = LocalTime.GetUtc5Time()
        };
}