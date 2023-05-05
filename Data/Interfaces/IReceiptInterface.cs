using DataLayer.Entities.Selling;
using DataLayer.VModels;

namespace DataLayer.Interfaces;

public interface IReceiptInterface : IRepository<Receipt>
{
    Task<IEnumerable<ReceiptViewDto>> GetReceiptsWithoutLoanAsync();
}