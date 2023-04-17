using DataLayer.Entities;

namespace BLL.Dtos.ProductDtos;

public class ProductViewDto : BaseDto
{
   public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string MadeIn { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public int WarningCount { get; set; }

    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public int SubcategoryId { get; set; }
    public string SubcategoryName { get; set; } = string.Empty;
    public string AdminId { get; set; } = string.Empty;
    public string AdminFullName { get; set; } = string.Empty;

    public static explicit operator ProductViewDto(Product v)
        => new ProductViewDto()
        {
            Id = v.Id,
            Name = v.Name,
            Description = v.Description,
            MadeIn = v.MadeIn,
            SubcategoryId = v.SubcategoryId,
            CategoryId= v.CategoryId,
            Barcode = v.Barcode,
            WarningCount = v.WarningCount,
            AdminId = v.AdminId
        };
}