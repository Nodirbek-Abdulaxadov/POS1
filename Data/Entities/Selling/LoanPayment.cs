using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Selling;

public class LoanPayment : BaseEntity
{
    public decimal PaidCash { get; set; }
    public decimal PaidCard { get; set; }
    [Required]
    public decimal TotalPayment { get; set; }

    public int LoanId { get; set; }
    public string SellerId { get; set; } = string.Empty;
}