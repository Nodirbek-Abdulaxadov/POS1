using DataLayer.Entities;
using DataLayer.VModels;

namespace DataLayer.Interfaces;

public interface IProductInterface : IRepository<Product>
{
    Task<IEnumerable<ProductViewDto>> GetAllWithTransactionAsync();
}