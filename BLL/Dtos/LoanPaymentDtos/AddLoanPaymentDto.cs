namespace BLL.Dtos.LoanPaymentDtos;

public class AddLoanPaymentDto
{
    public decimal PaidCash { get; set; }
    public decimal PaidCard { get; set; }
    public decimal TotalPayment { get; set; }

    public int LoanId { get; set; }
    public string SellerId { get; set; } = string.Empty;
}