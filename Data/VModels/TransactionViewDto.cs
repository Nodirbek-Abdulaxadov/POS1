namespace DataLayer.VModels;

public class TransactionViewDto
{
    public int Id { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal ProductPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public int ReceiptId { get; set; }
}