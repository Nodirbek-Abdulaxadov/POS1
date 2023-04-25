using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.VModels;
using Npgsql;

namespace DataLayer.Repositories;

public class TransferRepository : Repository<Transfer>, ITransferInterface
{
    private readonly AppDbContext _dbContext;
    private readonly TransferWarehouseItemInterface _transferItemService;
    private readonly IWarehouseItemInterface _warehouseItemInterface;

    public TransferRepository(AppDbContext dbContext, 
        TransferWarehouseItemInterface transferItemService,
        IWarehouseItemInterface warehouseItemInterface
        ) : base(dbContext)
    {
        _dbContext = dbContext;
        _transferItemService = transferItemService;
        _warehouseItemInterface = warehouseItemInterface;
    }

    public async Task<IEnumerable<TransferViewDto>> GetAllTransfers()
    {
        var connectionString = "Host=localhost; Database=Zakaz_POS1; User ID=postgres;  Port=5432; Password=1234; Pooling=true; TrustServerCertificate=true;";
        List<TransferViewDto> transfers = new List<TransferViewDto>();
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        try
        {
            connection.Open();

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = """
            SELECT t.*, COALESCE(w1."Name", 'Noma''lum') AS fromWarehouseName, 
                        COALESCE(w2."Name", 'Noma''lum') AS toWarehouseName,
                        COALESCE(u."FullName", 'Noma''lum') AS adminFullName,
                        COALESCE(s."Name", 'Noma''lum') AS supplierFullName
                        FROM "Transfers" t
                        LEFT JOIN "Warehouses" w1 ON w1."Id" = t."OutWarehouseId"
                        LEFT JOIN "Warehouses" w2 ON w2."Id" = t."InWarehouseId"
                        LEFT JOIN "AspNetUsers" u ON u."Id" = t."AdminId"
            			LEFT JOIN "Supplier" s ON s."Id" = t."SupplierId"
                        ORDER BY t."ModifiedDate" DESC;
            """;
            NpgsqlDataReader dataReader = await command.ExecuteReaderAsync();
            while (dataReader.Read())
            {
                transfers.Add(new TransferViewDto()
                {
                    id = dataReader.GetInt32(0),
                    fromWarehouseId = dataReader.GetInt32(1),
                    toWarehouseId = dataReader.GetInt32(2),
                    transferDate = dataReader.GetDateTime(3),
                    adminId = dataReader.GetString(4),
                    supplierId = dataReader.GetInt32(5),
                    addedDate = dataReader.GetDateTime(7),
                    lastModified = dataReader.GetDateTime(8),
                    fromWarehouseName = dataReader.GetString(9),
                    toWarehouseName = dataReader.GetString(10),
                    adminFullName = dataReader.GetString(11),
                    supplierFullName = dataReader.GetString(12),
                });
            }

            return transfers;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
    }
}