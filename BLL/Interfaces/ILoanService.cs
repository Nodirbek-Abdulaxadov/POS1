using BLL.Dtos.LoanDtos;

namespace BLL.Interfaces;

public interface ILoanService
{
    Task AddAsync(AddLoanDto dto);
    Task<IEnumerable<LoanViewDto>> GetAllAsync();
}