using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Interfaces;

namespace DataLayer.Repositories;

public class SupplierRepository : Repository<Supplier>, ISupplierInterface
{
    public SupplierRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}