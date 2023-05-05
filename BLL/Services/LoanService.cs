using BLL.Dtos.LoanDtos;
using BLL.Interfaces;
using DataLayer.Interfaces;

namespace BLL.Services;

public class LoanService : ILoanService
{
    private readonly IUnitOfWork _unitOfWork;

    public LoanService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task AddAsync(AddLoanDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<LoanViewDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}