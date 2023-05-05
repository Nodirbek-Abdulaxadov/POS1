using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Entities.Selling;
using DataLayer.Interfaces;
using DataLayer.VModels;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public class ReceiptRepository : Repository<Receipt>, IReceiptInterface
{
    private readonly AppDbContext dbContext;

    public ReceiptRepository(AppDbContext dbContext) 
        : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<ReceiptViewDto>> GetReceiptsWithoutLoanAsync()
    {
        var receipts = await dbContext.Receipts.ToListAsync();
        var transactions = await dbContext.Transactions.ToListAsync();
        var products = await dbContext.Products.ToListAsync();
        var warehouseItems = await dbContext.WarehousesItems.ToListAsync();
        var warehouses = await dbContext.Warehouses.ToListAsync();

        List<ReceiptViewDto> receiptViews = new List<ReceiptViewDto>();
        foreach (var receipt in receipts.Where(i => i.IsDeleted == false))
        {
            var warehouse = warehouses.FirstOrDefault(i => i.Id == receipt.WarehouseId);
            var receiptView = new ReceiptViewDto()
            {
                Id = receipt.Id,
                SellerId = receipt.SellerId,
                Discount = receipt.Discount,
                AddedDate = receipt.AddedDate,
                PaidCard = receipt.PaidCard,
                PaidCash = receipt.PaidCash,
                TotalPrice = receipt.TotalPrice,
                WarehouseId = receipt.WarehouseId,
                WarehouseName = (warehouse??new Warehouse()).Name
            };

            receiptView.Transactions.AddRange(transactions.Where(t => t.ReceiptId == receipt.Id).Select(r =>
            {
                var product = products.FirstOrDefault(p => p.Id == r.ProductId)??new Product();
                var warehouseItem = warehouseItems.FirstOrDefault(w => w.ProductId == product.Id)??new WarehouseItem();
                return new TransactionViewDto()
                {
                    Id = r.Id,
                    Barcode = product.Barcode,
                    ProductPrice = r.ProductPrice,
                    ProductName = r.ProductName,
                    ProductId = r.ProductId,
                    Quantity = r.Quantity,
                    ReceiptId = r.ReceiptId,
                    TotalPrice = r.TotalPrice,
                };
            }));
            receiptViews.Add(receiptView);
        }

        return receiptViews;
    }
}
