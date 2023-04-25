using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.VModels;
using Npgsql;

namespace DataLayer.Repositories;

public class ProductRepository : Repository<Product>, IProductInterface
{
    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<ProductViewDto>> GetAllWithTransactionAsync()
    {
        var connectionString = "Host=localhost; Database=Zakaz_POS1; User ID=postgres;  Port=5432; Password=1234; Pooling=true; TrustServerCertificate=true;";
        List<ProductViewDto> products = new List<ProductViewDto>();
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        try
        {
            connection.Open();

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = """
            SELECT p.*, COALESCE(u."FullName", 'Noma''lum') AS AdminFullName, 
            COALESCE(s."Name", 'Noma''lum') AS SubcategoryName,
            COALESCE(c."Name", 'Noma''lum') AS CategoryName
            FROM "Products" p
            LEFT JOIN "Subcategories" s ON s."Id" = p."SubcategoryId"
            LEFT JOIN "Categories" c ON c."Id" = p."CategoryId"
            LEFT JOIN "AspNetUsers" u ON u."Id" = p."AdminId"
            ORDER BY p."ModifiedDate" DESC;
            """;
            NpgsqlDataReader dataReader = await command.ExecuteReaderAsync();
            while (dataReader.Read())
            {
                products.Add(new ProductViewDto()
                {
                    Id = dataReader.GetInt32(0),
                    Name = dataReader.GetString(1),
                    WarningCount = dataReader.GetInt32(2),
                    Description = dataReader.GetString(3),
                    Barcode = dataReader.GetString(4),
                    MadeIn = dataReader.GetString(5),
                    SubcategoryId = dataReader.GetInt32(6),
                    AdminId = dataReader.GetString(7),
                    IsDeleted = dataReader.GetBoolean(8),
                    AddedDate = dataReader.GetDateTime(9),
                    ModifiedDate = dataReader.GetDateTime(10),
                    CategoryId = dataReader.GetInt32(11),
                    Quantity = dataReader.GetInt32(12),
                    AdminFullName = dataReader.GetString(13),
                    SubcategoryName = dataReader.GetString(14),
                    CategoryName = dataReader.GetString(15)
                });
            }

            return products;
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
