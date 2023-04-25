using DataLayer.VModels;

namespace BLL.Dtos.Transfers;

public class TransferDto
{
    public TransferDto()
    {
        items = new List<TransferItemDto>();
    }
    public int id { get; set; }
    public DateTime transferDate { get; set; }
    public int fromWarehouseId { get; set; }
    public string fromWarehouseName { get; set; } = string.Empty;
    public int toWarehouseId { get; set; }
    public string toWarehouseName { get; set; } = string.Empty;
    public string adminId { get; set; } = string.Empty;
    public string adminFullName { get; set; } = string.Empty;
    public int supplierId { get; set; }
    public string supplierFullName { get; set; } = string.Empty;
    public DateTime addedDate { get; set; }
    public DateTime lastModified { get; set; }

    public List<TransferItemDto> items { get; set; }

    public static explicit operator TransferDto(TransferViewDto v)
        => new TransferDto()
        {
            id = v.id,
            adminFullName = v.adminFullName,
            addedDate = v.addedDate,
            adminId = v.adminId,
            fromWarehouseId = v.fromWarehouseId,
            fromWarehouseName = v.fromWarehouseName,
            transferDate = v.transferDate,
            supplierFullName = v.supplierFullName,
            lastModified = v.lastModified,
            supplierId = v.supplierId,
            toWarehouseId = v.toWarehouseId,
            toWarehouseName = v.toWarehouseName,
            items = new List<TransferItemDto>()
        };
}