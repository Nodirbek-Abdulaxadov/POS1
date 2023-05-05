using BLL.Dtos.LoanPaymentDtos;

namespace BLL.Interfaces;

public interface ILoanPaymentService
{
        Task AddAsync(AddLoanPaymentDto dto);
}