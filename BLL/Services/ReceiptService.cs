using BLL.Dtos.ReceiptDtos;
using BLL.Dtos.TransactionDtos;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.Validations;
using Core;
using DataLayer.Entities.Selling;
using DataLayer.Interfaces;
using DataLayer.VModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services;

public class ReceiptService : IReceiptService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> userManager;

    public ReceiptService(IUnitOfWork unitOfWork, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        this.userManager = userManager;
    }


    public async Task<ReceiptDto> AddAsync(AddReceiptDto receiptDto, List<TransactionAsReceiptItemDto> items)
    {
        var receipt = await _unitOfWork.Receipts.AddAsync((Receipt)receiptDto);
        await _unitOfWork.SaveAsync();
        var products = await _unitOfWork.Products.GetAllAsync();
        var warehouseItems = await _unitOfWork.WarehouseItems.GetAllAsync();

        foreach (var item in items)
        {
            Transaction transaction = new()
            {
                AddedDate = LocalTime.GetUtc5Time(),
                IsDeleted = false,
                ModifiedDate = LocalTime.GetUtc5Time(),
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                ReceiptId = receipt.Id,
                TotalPrice = item.TotalPrice
            };
            transaction = await _unitOfWork.Transactions.AddAsync(transaction);
            await _unitOfWork.SaveAsync();

            var warehouseItem = (await _unitOfWork.WarehouseItems.GetAllAsync())
                                .OrderByDescending(x => x.ModifiedDate)
                                .FirstOrDefault(i => i.ProductId == transaction.ProductId);
            warehouseItem.Quantity -= item.Quantity;
            warehouseItem.ModifiedDate = LocalTime.GetUtc5Time();
            await _unitOfWork.WarehouseItems.UpdateAsync(warehouseItem);
            await _unitOfWork.SaveAsync();
        }

        return (ReceiptDto)receipt;
    }

    public async Task<PagedList<ReceiptViewDto>> GetPagedReceiptsWithoutLoans(int pageSize, int pageNumber)
    {
        var sellers = await userManager.Users.ToListAsync();
        var dtoList = (await _unitOfWork.Receipts.GetReceiptsWithoutLoanAsync())
                                                   .Select(i =>
                                                   {
                                                       var seller = sellers.FirstOrDefault(s => s.Id == i.SellerId);
                                                       i.SellerFullName = seller==null? "Noma'lum" : seller.FullName;
                                                       return i;
                                                   })
                                                   .OrderBy(d => d.AddedDate)
                                                   .ToList();

        if (dtoList.Count == 0)
        {
            throw new MarketException("Empty list");
        }

        PagedList<ReceiptViewDto> pagedList = new(dtoList.ToList(),
                                                     dtoList.Count(),
                                                     pageNumber, pageSize);

        if (pageNumber > pagedList.TotalPages || pageNumber < 1)
        {
            throw new ArgumentNullException("Page not fount!");
        }

        return pagedList.ToPagedList(dtoList, pageSize, pageNumber);
    }
}