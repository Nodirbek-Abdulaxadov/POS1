using BLL.Dtos.CategoryDtos;
using BLL.Helpers;
using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace BLL.Dtos.SubcategoryDtos;

public class UpdateSubcategoryDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public DateTime AddedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public static explicit operator Subcategory(UpdateSubcategoryDto v)
        => new Subcategory()
        {
            Id = v.Id,
            Name = v.Name,
            IsDeleted = false,
            AddedDate = v.AddedDate,
            ModifiedDate = LocalTime.GetUtc5Time()
        };
}