using DataLayer.Entities;

namespace DataLayer.Interfaces;

public interface TransferWarehouseItemInterface
{
    Task<IEnumerable<TransferWarehouseItem>> GetAllAsync();
    Task<TransferWarehouseItem?> GetByIdAsync(int id);
    Task<TransferWarehouseItem> AddAsync(TransferWarehouseItem entity);
    Task UpdateAsync(TransferWarehouseItem entity);
    Task RemoveAsync(TransferWarehouseItem entity);
}