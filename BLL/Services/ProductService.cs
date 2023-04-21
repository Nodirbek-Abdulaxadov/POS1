using BLL.Dtos.ProductDtos;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.Validations;
using Core;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public ProductService(IUnitOfWork unitOfWork, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task ActionAsync(int id, ActionType action)
    {
        var model = await _unitOfWork.Products.GetByIdAsync(id);

        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        switch (action)
        {
            case ActionType.Archive:
                {
                    model.IsDeleted = true;

                    await _unitOfWork.Products.UpdateAsync(model);
                }
                break;
            case ActionType.Recover:
                {
                    model.IsDeleted = false;
                    await _unitOfWork.Products.UpdateAsync(model);
                }
                break;
            case ActionType.Remove:
                {
                    await _unitOfWork.Products.RemoveAsync(model);
                }
                break;
        }

        await _unitOfWork.SaveAsync();
    }

    /// <summary>
    /// Add new product method
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>New product model</returns>
    /// <exception cref="MarketException"></exception>
    public async Task<ProductViewDto> AddAsync(AddProductDto dto)
    {
        if (!dto.IsValid())
        {
            throw new MarketException("All fields must be non empty value!");
        }

        var products = await _unitOfWork.Products.GetAllAsync();
        var barcodes = products.Select(p => p.Barcode).ToList();
        var exist = products.Where(x => x.Name == dto.Name)
                            .Any(p => p.IsEqual(dto));

        if (exist || barcodes.Any(b => b == dto.Barcode))
        {
            throw new MarketException("This product is already exist!");
        }

        var model = await _unitOfWork.Products.AddAsync((Product)dto);
        await _unitOfWork.SaveAsync();

        return (ProductViewDto)model;
    }

    public async Task<string> GenerateBarcodeAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync();
        var barcodes = products.Select(p => p.Barcode).ToList();
        Random random = new();
        goBack: var randomBarcode = random.NextInt64(1000000000000, 9999999999999);
        if (barcodes.Any(b => b == randomBarcode.ToString()))
        {
            goto goBack;
        }

        return randomBarcode.ToString();
    }

    /// <summary>
    /// Get all products method
    /// </summary>
    /// <returns>List of products</returns>
    public async Task<IEnumerable<ProductViewDto>> GetAllAsync()
    {
        var list = await _unitOfWork.Products.GetAllAsync();

        var categories = await _unitOfWork.Categories.GetAllAsync();
        var subcategories = await _unitOfWork.Subcategories.GetAllAsync();
        var users = _userManager.Users.ToList();

        var dtoList = list.Select(x =>
        {
            var model = (ProductViewDto)x;
            var subcategory = subcategories.FirstOrDefault(i => i.Id == model.SubcategoryId);
            var category = categories.FirstOrDefault(i => i.Id == model.CategoryId);
            var user = users.FirstOrDefault(u => u.Id == model.AdminId);

            model.AdminFullName = user == null ? "Noma'lum" : user.FullName;
            model.SubcategoryName = subcategory == null ? "Noma'lum" : subcategory.Name;
            model.CategoryName = category == null ? "Noma'lum" : category.Name;

            return model;
        });
        return dtoList;
    }

    public async Task<PagedList<ProductViewDto>> GetArchivedProductsAsync(int pageSize, int pageNumber)
    {
        var list = await _unitOfWork.Products.GetAllAsync();

        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        var categories = await _unitOfWork.Categories.GetAllAsync();
        var subcategories = await _unitOfWork.Subcategories.GetAllAsync();
        var users = _userManager.Users.ToList();

        var dtoList = list.Select(x =>
        {
            var model = (ProductViewDto)x;
            var subcategory = subcategories.FirstOrDefault(i => i.Id == model.SubcategoryId);
            var category = categories.FirstOrDefault(i => i.Id == model.CategoryId);
            var user = users.FirstOrDefault(u => u.Id == model.AdminId);

            model.AdminFullName = user == null ? "Noma'lum" : user.FullName;
            model.SubcategoryName = subcategory == null ? "Noma'lum" : subcategory.Name;
            model.CategoryName = category == null ? "Noma'lum" : category.Name;

            return model;
        }).ToList();

        if (dtoList.Count == 0)
        {
            throw new MarketException("Empty list");
        }

        PagedList<ProductViewDto> pagedList = new(dtoList.ToList(),
                                                     dtoList.Count(),
                                                     pageSize, pageNumber);

        if (pageNumber > pagedList.TotalPages || pageNumber < 1)
        {
            throw new ArgumentNullException("Page not fount!");
        }

        return pagedList.ToPagedList(dtoList, pageSize, pageNumber);
    }

    /// <summary>
    /// Get single product by id method
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Product model</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="MarketException"></exception>
    public async Task<ProductViewDto> GetByIdAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);

        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        var model = (ProductViewDto)product;
        var category = await _unitOfWork.Categories.GetByIdAsync(model.Id);
        var subcategory = await _unitOfWork.Subcategories.GetByIdAsync(model.Id);
        model.SubcategoryName = subcategory == null ? "Noma'lum" : subcategory.Name;
        model.CategoryName = category == null ? "Noma'lum" : category.Name;

        return model;
    }

    public async Task<List<DProduct>> GetDProducts()
    {
        var products = await _unitOfWork.Products.GetAllAsync();
        var warehouseItems = await _unitOfWork.WarehouseItems.GetAllAsync();
        List<DProduct> dProducts = new List<DProduct>();
        foreach (var product in products)
        {
            var productItems = warehouseItems.Where(d => d.ProductId == product.Id);
            var warItem = productItems.First();
            var model = new DProduct()
            {
                Id = product.Id,
                Name = product.Name,
                Barcode = product.Barcode,
                Description = product.Description,
                MadeIn = product.MadeIn,
                Price = warItem.SellingPrice,
                AvailableCount = productItems.Sum(d => d.Quantity)
            };
            dProducts.Add(model);
        }

        return dProducts;
    }

    /// <summary>
    /// Get paged list of products
    /// </summary>
    /// <param name="pageSize"></param>
    /// <param name="pageNumber"></param>
    /// <returns>Paged list</returns>
    public async Task<PagedList<ProductViewDto>> GetProductsAsync(int pageSize, int pageNumber)
    {
        var list = await _unitOfWork.Products.GetAllAsync();

        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        var categories = await _unitOfWork.Categories.GetAllAsync();
        var subcategories = await _unitOfWork.Subcategories.GetAllAsync();
        var users = _userManager.Users.ToList();

        var dtoList = list.Select(x =>
        {
            var model = (ProductViewDto)x;
            var subcategory = subcategories.FirstOrDefault(i => i.Id == model.SubcategoryId);
            var category = categories.FirstOrDefault(i => i.Id == model.CategoryId);
            var user = users.FirstOrDefault(u => u.Id == model.AdminId);

            model.AdminFullName = user == null ? "Noma'lum" : user.FullName;
            model.SubcategoryName = subcategory == null ? "Noma'lum" : subcategory.Name;
            model.CategoryName = category == null ? "Noma'lum" : category.Name;

            return model;
        }).ToList();

        if (dtoList.Count == 0)
        {
            throw new MarketException("Empty list");
        }

        PagedList<ProductViewDto> pagedList = new(dtoList.ToList(),
                                                     dtoList.Count(),
                                                     pageSize, pageNumber);

        if (pageNumber > pagedList.TotalPages || pageNumber < 1)
        {
            throw new ArgumentNullException("Page not fount!");
        }

        return pagedList.ToPagedList(dtoList, pageSize, pageNumber);
    }

    /// <summary>
    /// Update product method
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>Updated model</returns>
    /// <exception cref="MarketException"></exception>
    public async Task<ProductViewDto> UpdateAsync(ProductUpdateDto dto)
    {
        if (!dto.IsValid())
        {
            throw new MarketException("All fields must be non empty value!");
        }

        var model = await _unitOfWork.Products.GetByIdAsync(dto.Id);

        if (model == null)
        {
            throw new MarketException("Product is not found!");
        }

        dto.AddedDate = model.AddedDate;
        await _unitOfWork.Products.UpdateAsync((Product)dto);
        await _unitOfWork.SaveAsync();

        return (ProductViewDto)model;
    }
}