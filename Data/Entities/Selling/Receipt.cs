﻿using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Selling;

public class Receipt : BaseEntity
{
    [Required]
    public decimal TotalPrice { get; set; }
    [Required]
    public decimal Discount { get; set; }
    [Required]
    public decimal PaidCash { get; set; }
    [Required]
    public decimal PaidCard { get; set; }
    [Required]
    public bool HasLoan { get; set; }

    [Required]
    public string SellerId { get; set; } = string.Empty;
    public int WarehouseId { get; set; }


    public Loan Loan = new Loan();
    public IEnumerable<Transaction> Transactions = new List<Transaction>();
}
