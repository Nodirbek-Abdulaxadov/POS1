using BLL.Helpers;
using DataLayer.Entities;

namespace BLL.Dtos.ProductDtos;

public class ProductUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string MadeIn { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public int WarningCount { get; set; }

    public int CategoryId { get; set; }
    public int SubcategoryId { get; set; }
    public string AdminId { get; set; } = string.Empty;
    public DateTime AddedDate { get; set; }

    public static explicit operator Product(ProductUpdateDto v)
        => new Product()
        {
            Id = v.Id,
            Name = v.Name,
            Description = v.Description,
            MadeIn = v.MadeIn,
            ModifiedDate = LocalTime.GetUtc5Time(),
            AdminId = v.AdminId,
            SubcategoryId = v.SubcategoryId,
            CategoryId = v.CategoryId,
            Barcode = v.Barcode,
            WarningCount = v.WarningCount,
            AddedDate = v.AddedDate
        };
}