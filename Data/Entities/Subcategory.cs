namespace DataLayer.Entities;

public class Subcategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }

    public IEnumerable<Product> Subcategories = new List<Product>();
}