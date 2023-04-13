using BLL.Helpers;
using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace BLL.Dtos.CategoryDtos;

public class UpdateCategoryDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    public DateTime AddedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public static explicit operator Category(UpdateCategoryDto v)
        => new Category()
        {
            Id = v.Id,
            Name = v.Name,
            IsDeleted = false,
            AddedDate = v.AddedDate,
            ModifiedDate = LocalTime.GetUtc5Time()
        };
}