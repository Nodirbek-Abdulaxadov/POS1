using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public class TransferWarehouseItemRepository : TransferWarehouseItemInterface
{
    private readonly AppDbContext _dbContext;

    public TransferWarehouseItemRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TransferWarehouseItem> AddAsync(TransferWarehouseItem entity)
    {
        await _dbContext.TransferWarehouseItems.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<TransferWarehouseItem>> GetAllAsync()
        => await _dbContext.TransferWarehouseItems.ToListAsync();

    public async Task<TransferWarehouseItem?> GetByIdAsync(int id)
        => await _dbContext.TransferWarehouseItems.FirstOrDefaultAsync(i => i.Id == id);

    public Task RemoveAsync(TransferWarehouseItem entity)
    {
        _dbContext.TransferWarehouseItems.Remove(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(TransferWarehouseItem entity)
    {
        _dbContext.TransferWarehouseItems.Update(entity);
        return Task.CompletedTask;
    }
}