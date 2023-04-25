namespace DataLayer.VModels;

public class TransferViewDto 
{ 
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
}
