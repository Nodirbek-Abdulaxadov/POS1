namespace BLL.Dtos.LoanDtos;

public class AddLoanDto
{
    public decimal PaidCash { get; set; }
    public decimal PaidCard { get; set; }
    public decimal TotalPayment { get; set; }
    public decimal LeftAmount { get; set; }
    public int ReceiptId { get; set; }
    public int CustomerId { get; set; }
    public string SellerId { get; set; } = string.Empty;
}