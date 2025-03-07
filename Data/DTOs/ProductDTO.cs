using App.Data.Entities;

namespace SimoshStore;

public class ProductDTO
{
    public int CategoryId { get; set; }
    public int? DiscountId { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;
    public int StockAmount { get; set; }
    public bool Enabled { get; set; } = true;
}