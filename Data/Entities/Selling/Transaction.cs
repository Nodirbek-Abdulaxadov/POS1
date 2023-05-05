using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Selling;

public class Transaction : BaseEntity
{
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal TotalPrice { get; set; }
    [Required]
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal ProductPrice { get; set; }
    [Required]
    public int ReceiptId { get; set; }
}
