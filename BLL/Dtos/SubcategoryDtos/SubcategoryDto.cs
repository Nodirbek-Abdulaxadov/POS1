using DataLayer.Entities;

namespace BLL.Dtos.SubcategoryDtos;

public class SubcategoryDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime AddedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    public static explicit operator SubcategoryDto(Subcategory v)
        => new SubcategoryDto()
        {
            Id = v.Id,
            Name = v.Name,
            AddedDate = v.AddedDate,
            ModifiedDate = v.ModifiedDate,
            CategoryId = v.CategoryId
        };
}