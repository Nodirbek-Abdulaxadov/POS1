using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class WarehouseItemRepository : Repository<WarehouseItem>, IWarehouseItemInterface
    {
        private readonly AppDbContext _dbContext;

        public WarehouseItemRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void MultipleUpdatePrice(int productId, int warehouseId, decimal price)
        {
            _dbContext.WarehousesItems
                .Where(i => i.ProductId == productId && i.WarehouseId == warehouseId)
                .ExecuteUpdate(wi => wi.SetProperty(
                        item => item.SellingPrice,
                        item => price
                    ));
        }
    }
}
