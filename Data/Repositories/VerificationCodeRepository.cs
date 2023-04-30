using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Interfaces;

namespace DataLayer.Repositories;

public class VerificationCodeRepository : Repository<VerificationCode>, IVerificationCodeInterface
{
    public VerificationCodeRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
