using BLL.Dtos.WarehouseItemDtos;

namespace BLL.Dtos.Transfers;

public class TransferItemDto
{
    public int Id { get; set; }
    public int TransferId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
}