using BLL.Dtos.LoanDtos;
using BLL.Helpers;

namespace BLL.Interfaces;

public interface ILoanService
{
    Task AddAsync(AddLoanDto dto);
    Task<PagedList<LoanViewDto>> GetAllPagedAsync(int pageSize, int pageNumber);
}