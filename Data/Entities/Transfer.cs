namespace DataLayer.Entities;

public class Transfer : BaseEntity
{
    public int OutWarehouseId { get; set; }
    public int InWarehouseId { get; set; }
    public DateTime TransferDate { get; set; }
    public string AdminId { get; set; } = string.Empty;
    public int SupplierId { get; set; }
}