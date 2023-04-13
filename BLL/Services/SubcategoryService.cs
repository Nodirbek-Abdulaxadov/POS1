using BLL.Dtos.SubcategoryDtos;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.Validations;
using DataLayer.Entities;
using DataLayer.Interfaces;

namespace BLL.Services;

public class SubcategoryService : ISubcategoryService 
{
    private readonly IUnitOfWork _unitOfWork;

    public SubcategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task ActionAsync(int id, ActionType action)
    {
        var model = await _unitOfWork.Subcategories.GetByIdAsync(id);

        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        switch (action)
        {
            case ActionType.Archive:
                {
                    model.IsDeleted = true;

                    await _unitOfWork.Subcategories.UpdateAsync(model);
                }
                break;
            case ActionType.Recover:
                {
                    model.IsDeleted = false;
                    await _unitOfWork.Subcategories.UpdateAsync(model);
                }
                break;
            case ActionType.Remove:
                {
                    await _unitOfWork.Subcategories.RemoveAsync(model);
                }
                break;
        }

        await _unitOfWork.SaveAsync();
    }

    public async Task<SubcategoryDto> AddAsync(AddSubcategoryDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        if (string.IsNullOrEmpty(dto.Name))
        {
            throw new ArgumentNullException(nameof(dto.Name));
        }

        var list = await GetAllAsync();
        if (list.Any(x => x.Name == dto.Name))
        {
            throw new MarketException("This category name is already exist!");
        }

        var model = await _unitOfWork.Subcategories.AddAsync((Subcategory)dto);
        await _unitOfWork.SaveAsync();

        return (SubcategoryDto)model;
    }

    public async Task<IEnumerable<SubcategoryDto>> GetAllAsync()
    {
        var list = await _unitOfWork.Subcategories.GetAllAsync();

        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }
        var categories = await _unitOfWork.Categories.GetAllAsync();
        var dtoList = list.Select(x =>
        {
            var model = (SubcategoryDto)x;
            var category = categories.FirstOrDefault(i => i.Id == x.CategoryId);
            model.CategoryId = x.CategoryId;
            model.CategoryName = category.Name;
            return model;
        });
        return dtoList;
    }

    public async Task<PagedList<SubcategoryDto>> GetArchivedSubcategoriesAsync(int pageSize, int pageNumber)
    {

        var categories = await _unitOfWork.Categories.GetAllAsync();
        var dtoList = (await _unitOfWork.Subcategories.GetAllAsync())
                                                   .Where(w => w.IsDeleted == true)
                                                   .Select(i =>
                                                   {
                                                       {
                                                           var model = (SubcategoryDto)i;
                                                           var category = categories.FirstOrDefault(i => i.Id == model.CategoryId);
                                                           model.CategoryName = category.Name;
                                                           return model;
                                                       }
                                                   })
                                                   .ToList();

        PagedList<SubcategoryDto> pagedList = new(dtoList.ToList(),
                                                     dtoList.Count(),
                                                     pageSize, pageNumber);

        if (pageNumber > pagedList.TotalPages || pageNumber < 1)
        {
            throw new MarketException("Page not fount!");
        }

        return pagedList.ToPagedList(dtoList, pageSize, pageNumber);
    }

    public async Task<SubcategoryDto> GetByIdAsync(int id)
    {
        var warehouse = await _unitOfWork.Subcategories.GetByIdAsync(id);
        if (warehouse == null)
        {
            throw new ArgumentNullException(nameof(warehouse));
        }

        return (SubcategoryDto)warehouse;
    }

    public async Task<PagedList<SubcategoryDto>> GetSubcategoriesAsync(int pageSize, int pageNumber)
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();
        var dtoList = (await _unitOfWork.Subcategories.GetAllAsync())
                                                   .Where(w => w.IsDeleted == false)
                                                   .Select(i =>
                                                   {
                                                       {
                                                           var model = (SubcategoryDto)i;
                                                           var category = categories.FirstOrDefault(i => i.Id == model.CategoryId);
                                                           model.CategoryName = category.Name;
                                                           return model;
                                                       }
                                                   })
                                                   .ToList();

        PagedList<SubcategoryDto> pagedList = new(dtoList.ToList(),
                                                     dtoList.Count(),
                                                     pageSize, pageNumber);

        if (pageNumber > pagedList.TotalPages || pageNumber < 1)
        {
            throw new MarketException("Page not fount!");
        }

        return pagedList.ToPagedList(dtoList, pageSize, pageNumber);
    }

    public async Task<SubcategoryDto> UpdateAsync(UpdateSubcategoryDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        if (string.IsNullOrEmpty(dto.Name))
        {
            throw new ArgumentNullException(nameof(dto.Name));
        }

        var model = await _unitOfWork.Subcategories.GetByIdAsync(dto.Id);

        if (model == null)
        {
            throw new MarketException("Warehouse is not found!");
        }

        model = (Subcategory)dto;
        await _unitOfWork.Subcategories.UpdateAsync(model);
        await _unitOfWork.SaveAsync();

        var res = await GetByIdAsync(dto.Id);
        return res;
    }
}