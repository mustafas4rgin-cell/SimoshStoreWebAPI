
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimoshStore;

namespace App.Data.Entities;

public class ProductEntity : EntityBase, IHasEnabled
{
    public int SellerId { get; set; } = 2;
    public int CategoryId { get; set; }
    public int? DiscountId { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;
    public int StockAmount { get; set; }
    public bool Enabled { get; set; } = true;

    // Navigation properties
    public UserEntity Seller { get; set; } = null!;

    public CategoryEntity Category { get; set; } = null!;
    public DiscountEntity? Discount { get; set; }

    public ICollection<ProductImageEntity> Images { get; set; } = null!;
    public ICollection<ProductCommentEntity> Comments { get; set; } = new List<ProductCommentEntity>(); 
}

internal class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.SellerId).IsRequired();
        builder.Property(e => e.CategoryId).IsRequired();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Price).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.StockAmount).IsRequired();
        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.Enabled).IsRequired();

        builder.HasOne(d => d.Seller)
            .WithMany()
            .HasForeignKey(d => d.SellerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.Category)
            .WithMany()
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(d => d.Discount)
            .WithMany()
            .HasForeignKey(d => d.DiscountId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(d => d.Images)
            .WithOne(p => p.Product)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.Comments)
            .WithOne(p => p.Product)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.Cascade);




    }
}

internal class ProductEntitySeed : IEntityTypeSeed<ProductEntity>
{
    private static readonly Random _rnd = Random.Shared;

    public void SeedData(EntityTypeBuilder<ProductEntity> builder)
{
    builder.HasData(
        new List<ProductEntity> {
            new() { Id = 1, Name = "Apple", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Red Apple", StockAmount = 150, CreatedAt = new DateTime(2025, 2, 23), DiscountId = 1 },
            new() { Id = 2, Name = "Orange", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Sweet Oranges", StockAmount = 120, CreatedAt = new DateTime(2025, 2, 23), DiscountId = 2 },
            new() { Id = 3, Name = "Broccoli", CategoryId = 2, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Green Broccoli", StockAmount = 80, CreatedAt = new DateTime(2025, 2, 23), DiscountId = 3 },
            new() { Id = 4, Name = "Carrot", CategoryId = 2, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Organic Carrot", StockAmount = 200, CreatedAt = new DateTime(2025, 2, 23), DiscountId = 1 },
            new() { Id = 5, Name = "Tomato", CategoryId = 2, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Red Tomato", StockAmount = 100, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 6, Name = "Cucumber", CategoryId = 2, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Crisp Cucumber", StockAmount = 60, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 7, Name = "Banana", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Yellow Bananas", StockAmount = 140, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 8, Name = "Pineapple", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Sweet Pineapples", StockAmount = 90, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 9, Name = "Grapes", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Grapes", StockAmount = 110, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 10, Name = "Strawberries", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Sweet Strawberries", StockAmount = 75, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 11, Name = "Mango", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Ripe Mangoes", StockAmount = 80, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 12, Name = "Watermelon", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Juicy Watermelon", StockAmount = 100, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 13, Name = "Pomegranate", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Pomegranate", StockAmount = 120, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 14, Name = "Peach", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Sweet Peaches", StockAmount = 110, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 15, Name = "Cherries", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Cherries", StockAmount = 90, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 16, Name = "Avocado", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Ripe Avocados", StockAmount = 80, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 17, Name = "Blueberries", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Blueberries", StockAmount = 95, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 18, Name = "Figs", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Figs", StockAmount = 100, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 19, Name = "Coconut", CategoryId = 3, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Coconut", StockAmount = 60, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 20, Name = "Red Meat", CategoryId = 1, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Red Meat", StockAmount = 150, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 21, Name = "Chicken Breast", CategoryId = 1, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Chicken Breast", StockAmount = 100, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 22, Name = "Ground Beef", CategoryId = 1, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Ground Beef", StockAmount = 120, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 23, Name = "Pork", CategoryId = 1, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Pork", StockAmount = 80, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 24, Name = "Lamb", CategoryId = 1, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Lamb", StockAmount = 60, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 25, Name = "Hamburger", CategoryId = 7, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Juicy Hamburger", StockAmount = 200, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 26, Name = "Pizza", CategoryId = 7, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Delicious Pizza", StockAmount = 150, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 27, Name = "Spaghetti", CategoryId = 7, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Tasty Spaghetti", StockAmount = 120, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 28, Name = "Tacos", CategoryId = 7, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Delicious Tacos", StockAmount = 180, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 29, Name = "Fried Chicken", CategoryId = 7, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Crispy Fried Chicken", StockAmount = 150, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 30, Name = "Lasagna", CategoryId = 7, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Cheesy Lasagna", StockAmount = 100, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 31, Name = "Sushi", CategoryId = 7, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Sushi", StockAmount = 90, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 32, Name = "Bagels", CategoryId = 7, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Delicious Bagels", StockAmount = 130, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 33, Name = "Burgers", CategoryId = 7, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Tasty Burgers", StockAmount = 120, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 34, Name = "Pasta", CategoryId = 7, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Pasta", StockAmount = 100, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 35, Name = "Fried Fish", CategoryId = 7, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Crispy Fried Fish", StockAmount = 150, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 36, Name = "Grilled Chicken", CategoryId = 7, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Tender Grilled Chicken", StockAmount = 110, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 37, Name = "Salad", CategoryId = 2, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Healthy Salad", StockAmount = 180, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 38, Name = "Bacon", CategoryId = 1, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Crispy Bacon", StockAmount = 90, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 39, Name = "Eggs", CategoryId = 1, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Fresh Eggs", StockAmount = 200, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 40, Name = "Cereal", CategoryId = 5, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Healthy Cereal", StockAmount = 250, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 41, Name = "Oats", CategoryId = 5, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Organic Oats", StockAmount = 220, CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 42, Name = "Peanut Butter", CategoryId = 5, SellerId = 2, Price = _rnd.Next(10, 540), Description = "Smooth Peanut Butter", StockAmount = 150, CreatedAt = new DateTime(2025, 2, 23) },
        });
}

}