namespace BLL.Dtos.ProductDtos;

public class DProduct
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string MadeIn { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public int AvailableCount { get; set; }
    public decimal Price { get; set; }
}
