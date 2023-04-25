using BLL.Dtos.Transfers;
using BLL.Dtos.WarehouseDtos;
using BLL.Dtos.WarehouseItemDtos;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.Validations;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.VModels;

namespace BLL.Services;

public class TransferService : ITransferService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWarehouseItemService _warehouseItemService;

    public TransferService(IUnitOfWork unitOfWork, 
        IWarehouseItemService warehouseItemService)
    {
        _unitOfWork = unitOfWork;
        _warehouseItemService = warehouseItemService;
    }

    public async Task CreateNewTransferAsync(TransferParametrs parametrs,
                                             List<TransferItem> transferitems)
    {
        if (!transferitems.Any())
        {
            throw new ArgumentNullException(nameof(transferitems));
        }

        var fromWarehouse = await _unitOfWork.Warehouses.GetByIdAsync(parametrs.fromWarehouseId);
        if (fromWarehouse == null)
        {
            throw new MarketException("From Warehouse not found!");
        }

        var toWarehouse = await _unitOfWork.Warehouses.GetByIdAsync(parametrs.toWarehouseId);
        if (toWarehouse == null)
        {
            throw new MarketException("To Warehouse not found!");
        }

        var warehouseItems = (await _unitOfWork.WarehouseItems.GetAllAsync())
                                    .Where(i => transferitems.Any(t => t.ProductId == i.ProductId)
                                                && i.WarehouseId == parametrs.fromWarehouseId);

        Transfer transfer = new()
        {
            InWarehouseId = parametrs.toWarehouseId,
            OutWarehouseId = parametrs.fromWarehouseId,
            AdminId = parametrs.adminId,
            SupplierId = parametrs.suppplierId,
            TransferDate = DateTime.Parse(parametrs.transferDate),
            AddedDate = LocalTime.GetUtc5Time(),
            ModifiedDate = LocalTime.GetUtc5Time(),
            IsDeleted = false
        };
        transfer = await _unitOfWork.Transfers.AddAsync(transfer);
        await _unitOfWork.SaveAsync();

        foreach ( var item in transferitems )
        {
            var warehouseItem = warehouseItems.FirstOrDefault(i => i.ProductId == item.ProductId);
            if (warehouseItem == null)
            {
                throw new ArgumentNullException(nameof(warehouseItem));
            }

            if (warehouseItem.Quantity < item.Quantity)
            {
                throw new MarketException("There is no enough item quantity in " + warehouseItem.Id);
            }

            warehouseItem.Quantity -= item.Quantity;
            AddWarehouseItemDto newWarehouseItem = new()
            {
                Quantity = item.Quantity,
                AdminId = warehouseItem.AdminId,
                BroughtDate = DateOnly.Parse(warehouseItem.BroughtDate),
                IncomingPrice = warehouseItem.IncomingPrice,
                SellingPrice = warehouseItem.SellingPrice,
                ProductId = warehouseItem.ProductId,
                WarehouseId = parametrs.toWarehouseId
            };

            await _warehouseItemService.AddAsync(newWarehouseItem);
            await _unitOfWork.WarehouseItems.UpdateAsync(warehouseItem);

            TransferWarehouseItem transferWarehouseItem = new()
            {
                WarehouseItemId = warehouseItem.Id,
                TransferId = transfer.Id
            };
            await _unitOfWork.TransferWarehouseItems.AddAsync(transferWarehouseItem);
            await _unitOfWork.SaveAsync();
        }
    }

    public async Task<PagedList<TransferDto>> GetPagedAsync(int pageNumber, int pageSize)
    {
        var list = (await _unitOfWork.Transfers.GetAllTransfers())
                            .Select(t => (TransferDto)t);
        if (!list.Any())
        {
            throw new MarketException("Empty list");
        }

        PagedList<TransferDto> pagedList = new(list.ToList(),
                                                     list.Count(),
                                                     pageSize, pageNumber);

        if (pageNumber > pagedList.TotalPages || pageNumber < 1)
        {
            throw new ArgumentNullException("Page not fount!");
        }

        var products = await _unitOfWork.Products.GetAllAsync();
        var warehouseItems = await _unitOfWork.WarehouseItems.GetAllAsync();
        var transferWarehouseItems = await _unitOfWork.TransferWarehouseItems.GetAllAsync();

        List<TransferDto> resultList = new();

        foreach (var transfer in list)
        {
            var transferItems = transferWarehouseItems.Where(t => t.TransferId == transfer.id);
            if (transferItems.Any())
            {
                foreach (var transferItem in transferItems)
                {
                    TransferItemDto transferItemDto = new()
                    {
                        Id = transferItem.Id,
                        TransferId = transferItem.Id,
                        Quantity = transferItem.Quantity,
                        ProductName = products.FirstOrDefault(p =>
                            p.Id == warehouseItems.FirstOrDefault(w =>
                                w.Id == transferItem.WarehouseItemId).ProductId).Name
                    };
                    transfer.items.Add(transferItemDto);
                }
            }

            resultList.Add(transfer);
        }

        return pagedList.ToPagedList(resultList, pageSize, pageNumber);
    }
}