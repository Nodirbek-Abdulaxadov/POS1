namespace DataLayer.VModels;

public class ReceiptViewDto
{
    public int Id { get; set; }
    public DateTime AddedDate { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal PaidCash { get; set; }
    public decimal PaidCard { get; set; }
    public string SellerId { get; set; } = string.Empty;
    public string SellerFullName { get; set; } = string.Empty;
    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; } = string.Empty;

    public List<TransactionViewDto> Transactions = new();
}