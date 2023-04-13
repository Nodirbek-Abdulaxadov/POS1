using DataLayer.Entities;

namespace BLL.Dtos.CategoryDtos;

public class CategoryViewDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime AddedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public static explicit operator CategoryViewDto(Category v)
        => new CategoryViewDto()
        {
            Id = v.Id,
            Name = v.Name,
            AddedDate = v.AddedDate,
            ModifiedDate = v.ModifiedDate,
        };
}