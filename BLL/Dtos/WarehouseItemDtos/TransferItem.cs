namespace BLL.Dtos.WarehouseItemDtos;

public record TransferItem (
    int ProductId,
    int Quantity
);

public record TransferParametrs(
    int fromWarehouseId,
    int toWarehouseId,
    string adminId,
    string transferDate,
    int suppplierId
);