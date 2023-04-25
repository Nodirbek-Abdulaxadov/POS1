using DataLayer.Entities;

namespace DataLayer.Interfaces;

public interface IWarehouseItemInterface : IRepository<WarehouseItem>
{
    void MultipleUpdatePrice(int productId, int warehouseId, decimal price);
}