using BLL.Dtos.LoanPaymentDtos;

namespace BLL.Dtos.LoanDtos;

public class LoanViewDto : BaseDto
{
    public decimal PaidCash { get; set; }
    public decimal PaidCard { get; set; }
    public decimal TotalPayment { get; set; }
    public decimal LeftAmount { get; set; }
    public int ReceiptId { get; set; }
    public int CustomerId { get; set; }
    public string CustomerFullName { get; set; } = string.Empty;
    public int SellerId { get; set; }
    public string SellerFullName { get; set; } = string.Empty;

    public List<LoanPaymentViewDto> Payments = new();
}