using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Interfaces;

namespace DataLayer.Repositories;

public class SubcategoryRepository : Repository<Subcategory>, ISubcategoryInterface
{
    public SubcategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}