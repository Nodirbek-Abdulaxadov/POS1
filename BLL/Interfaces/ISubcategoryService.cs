using BLL.Dtos.SubcategoryDtos;
using BLL.Helpers;

namespace BLL.Interfaces;

public interface ISubcategoryService
{
    Task<PagedList<SubcategoryDto>> GetSubcategoriesAsync(int pageSize, int pageNumber);
    Task<PagedList<SubcategoryDto>> GetArchivedSubcategoriesAsync(int pageSize, int pageNumber);
    Task<IEnumerable<SubcategoryDto>> GetAllAsync();

    Task<SubcategoryDto> GetByIdAsync(int id);
    Task<SubcategoryDto> AddAsync(AddSubcategoryDto dto);

    Task<SubcategoryDto> UpdateAsync(UpdateSubcategoryDto dto);
    Task ActionAsync(int id, ActionType action);
}