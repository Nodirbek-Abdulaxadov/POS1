using DataLayer.Entities;
using DataLayer.VModels;

namespace DataLayer.Interfaces;

public interface ITransferInterface : IRepository<Transfer>
{
    Task<IEnumerable<TransferViewDto>> GetAllTransfers();
}