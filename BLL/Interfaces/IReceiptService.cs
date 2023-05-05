using BLL.Dtos.ReceiptDtos;
using BLL.Dtos.TransactionDtos;
using BLL.Helpers;
using DataLayer.VModels;

namespace BLL.Interfaces;

public interface IReceiptService
{
    Task<ReceiptDto> AddAsync(AddReceiptDto receiptDto, List<TransactionAsReceiptItemDto> items);

    Task<PagedList<ReceiptViewDto>> GetPagedReceiptsWithoutLoans(int pageSize, int pageNumber);
}