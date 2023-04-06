using BLL.Helpers;
using DataLayer.Entities;

namespace BLL.Dtos.ProductDtos;

public class AddProductDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string MadeIn { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public int WarningCount { get; set; }

    public int SubcategoryId { get; set; }
    public string AdminId { get; set; } = string.Empty;

    public static explicit operator Product(AddProductDto v)
        => new Product()
        {
            Name = v.Name,
            Description = v.Description,
            MadeIn = v.MadeIn,
            Barcode = v.Barcode,
            AdminId = v.AdminId,
            WarningCount = v.WarningCount,
            AddedDate = LocalTime.GetUtc5Time(),
            ModifiedDate = LocalTime.GetUtc5Time(),
            IsDeleted = false,
            SubcategoryId = v.SubcategoryId
        };
}