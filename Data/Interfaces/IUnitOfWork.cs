﻿namespace DataLayer.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICustomerInterface Customers { get; }
    ILoanInterface Loans { get; }
    ILoanPaymentInterface LoanPayments { get; }
    IProductInterface Products { get; }
    IReceiptInterface Receipts { get; }
    ITransactionInterface Transactions { get; }
    IWarehouseInterface Warehouses { get; }
    IWarehouseItemInterface WarehouseItems { get; }
    ICategoryInterface Categories { get; }
    ISubcategoryInterface Subcategories { get; }
    ISupplierInterface Suppliers { get; }
    TransferWarehouseItemInterface TransferWarehouseItems { get; }
    ITransferInterface Transfers { get; }
    IVerificationCodeInterface VerificationCodes { get; }
    Task SaveAsync();
}
