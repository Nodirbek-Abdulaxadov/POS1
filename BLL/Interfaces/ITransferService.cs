using BLL.Dtos.Transfers;
using BLL.Dtos.WarehouseItemDtos;
using BLL.Helpers;

namespace BLL.Interfaces;

public interface ITransferService
{
    Task CreateNewTransferAsync(TransferParametrs parametrs, List<TransferItem> transferitems);
    Task<PagedList<TransferDto>> GetPagedAsync(int pageNumber, int pageSize);
}