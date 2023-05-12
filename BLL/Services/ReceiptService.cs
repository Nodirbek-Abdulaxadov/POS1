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
                ProductPrice = item.ProductPrice,
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                ReceiptId = receipt.Id,
                TotalPrice = item.TotalPrice
            };
            transaction = await _unitOfWork.Transactions.AddAsync(transaction);
            await _unitOfWork.SaveAsync();

            var warehouseItem = warehouseItems.OrderByDescending(x => x.ModifiedDate)
                                .FirstOrDefault(i => i.ProductId == transaction.ProductId);

            var quantity = item.Quantity;
            var product = products.FirstOrDefault(p => p.Id == item.ProductId);
            product.Quantity -= quantity;
            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.SaveAsync();
            if (warehouseItem.Quantity > quantity)
            {
                warehouseItem.Quantity -= item.Quantity;
                warehouseItem.ModifiedDate = LocalTime.GetUtc5Time();
                await _unitOfWork.WarehouseItems.UpdateAsync(warehouseItem);
                await _unitOfWork.SaveAsync();
            }
            else
            {
                var warehouseItemsForItem = warehouseItems.Where(i => i.ProductId == item.ProductId)
                                                          .OrderByDescending(x => x.ModifiedDate);

                foreach (var wItem in warehouseItemsForItem)
                {
                    if (quantity < 1)
                    {
                        break;
                    }

                    if (wItem.Quantity >= quantity)
                    {
                        wItem.Quantity -= quantity;
                        wItem.ModifiedDate = LocalTime.GetUtc5Time();
                        await _unitOfWork.WarehouseItems.UpdateAsync(wItem);
                        await _unitOfWork.SaveAsync();
                        break;
                    }
                    else
                    {
                        wItem.Quantity = 0;
                        wItem.ModifiedDate = LocalTime.GetUtc5Time();
                        await _unitOfWork.WarehouseItems.UpdateAsync(wItem);
                        await _unitOfWork.SaveAsync();
                        quantity -= wItem.Quantity;
                    }
                }
            }

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
                                                   .OrderByDescending(d => d.AddedDate)
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