namespace DataLayer.Entities;

public class TransferWarehouseItem
{
    public int Id { get; set; }
    public int TransferId { get; set; }
    public int WarehouseItemId { get; set; }
    public int Quantity { get; set; }
}