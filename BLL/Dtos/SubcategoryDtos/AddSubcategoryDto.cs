using BLL.Helpers;
using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace BLL.Dtos.SubcategoryDtos;

public class AddSubcategoryDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }

    public static explicit operator Subcategory(AddSubcategoryDto v)
        => new Subcategory()
        {
            Name = v.Name,
            IsDeleted = false,
            AddedDate = LocalTime.GetUtc5Time(),
            ModifiedDate = LocalTime.GetUtc5Time(),
            CategoryId = v.CategoryId
        };
}