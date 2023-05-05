using DataLayer.Entities.Selling;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.VModels;

public class LoanViewDto
{
    public int Id { get; set; }
    public DateTime AddedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public string GivenDate { get; set; } = string.Empty;
    public decimal PaidAmount { get; set; }
    public decimal LeftAmount { get; set; }
    public int ReceiptId { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
}