namespace BLL.Dtos.TransactionDtos;

public class TransactionAsReceiptItemDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}