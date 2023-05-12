namespace BLL.Dtos.LoanPaymentDtos;

public class LoanPaymentViewDto : BaseDto
{
    public decimal PaidCash { get; set; }
    public decimal PaidCard { get; set; }
    public decimal TotalPayment { get; set; }
    public DateTime PaidDate { get; set; }

    public int LoanId { get; set; }
    public string SellerId { get; set; } = string.Empty;
    public string SellerFullName { get; set; } = string.Empty;
}