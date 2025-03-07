using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimoshStore;

namespace App.Data.Entities;

public class ProductCommentEntity : EntityBase
{
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public string Text { get; set; } = null!;
    public int StarCount { get; set; }
    public bool IsConfirmed { get; set; }

    // Navigation properties
    public ProductEntity Product { get; set; } = null!;

    public UserEntity User { get; set; } = null!;
}

internal class ProductCommentEntityConfiguration : IEntityTypeConfiguration<ProductCommentEntity>
{
    public void Configure(EntityTypeBuilder<ProductCommentEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ProductId).IsRequired();
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.Text).IsRequired().HasMaxLength(500);
        builder.Property(e => e.StarCount).IsRequired(); // 3 stars by default
        builder.Property(e => e.IsConfirmed).IsRequired(); // Not confirmed by default
        builder.Property(e => e.CreatedAt).IsRequired();

        builder.HasOne(d => d.Product)
            .WithMany(e => e.Comments)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.User)
            .WithMany()
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
    internal class ProductCommentEntitySeed : IEntityTypeSeed<ProductCommentEntity>
{
    public void SeedData(EntityTypeBuilder<ProductCommentEntity> builder)
    {
        builder.HasData(
            new List<ProductCommentEntity>
            {
                // Product 1 Comments
                new() { Id = 1, ProductId = 1, UserId = 1, Text = "Great product, really helpful!", StarCount = 5, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 1) },
                new() { Id = 2, ProductId = 1, UserId = 2, Text = "Not worth the price, very disappointing.", StarCount = 2, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 2) },

                // Product 2 Comments
                new() { Id = 3, ProductId = 2, UserId = 3, Text = "Absolutely love it! Highly recommend.", StarCount = 5, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 3) },
                new() { Id = 4, ProductId = 2, UserId = 3, Text = "The quality could be better. Expected more.", StarCount = 3, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 4) },

                // Product 3 Comments
                new() { Id = 5, ProductId = 3, UserId = 3, Text = "Great value for money, I'm satisfied!", StarCount = 4, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 5) },
                new() { Id = 6, ProductId = 3, UserId = 3, Text = "Terrible product. It broke after a week.", StarCount = 1, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 6) },

                // Product 4 Comments
                new() { Id = 7, ProductId = 4, UserId = 3, Text = "Perfect, just as described. Very happy with it.", StarCount = 5, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 7) },
                new() { Id = 8, ProductId = 4, UserId = 3, Text = "Doesn't match the description. Quite disappointed.", StarCount = 2, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 8) },

                // Product 5 Comments
                new() { Id = 9, ProductId = 5, UserId = 3, Text = "Amazing! The quality is top-notch.", StarCount = 5, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 9) },
                new() { Id = 10, ProductId = 5, UserId = 3, Text = "It's okay, but could be improved.", StarCount = 3, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 10) },

                // Product 6 Comments
                new() { Id = 11, ProductId = 6, UserId = 3, Text = "Doesn't work as expected. Very poor quality.", StarCount = 1, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 11) },
                new() { Id = 12, ProductId = 6, UserId = 3, Text = "Good product overall, would buy again.", StarCount = 4, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 12) },

                // Product 7 Comments
                new() { Id = 13, ProductId = 7, UserId = 3, Text = "Love it! Very stylish and comfortable.", StarCount = 5, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 13) },
                new() { Id = 14, ProductId = 7, UserId = 3, Text = "Not bad, but I was expecting a better fit.", StarCount = 3, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 14) },

                // Product 8 Comments
                new() { Id = 15, ProductId = 8, UserId = 3, Text = "Excellent, exactly what I needed!", StarCount = 5, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 15) },
                new() { Id = 16, ProductId = 8, UserId = 3, Text = "Not impressed, had issues with sizing.", StarCount = 2, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 16) },

                // Product 9 Comments
                new() { Id = 17, ProductId = 9, UserId = 3, Text = "Good quality for the price. Would recommend.", StarCount = 4, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 17) },
                new() { Id = 18, ProductId = 9, UserId = 3, Text = "Quality was poor. Not worth the money.", StarCount = 1, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 18) },

                // Product 10 Comments
                new() { Id = 19, ProductId = 10, UserId = 3, Text = "Very happy with the purchase. Highly recommended!", StarCount = 5, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 19) },
                new() { Id = 20, ProductId = 10, UserId = 3, Text = "The product is decent but could use some improvements.", StarCount = 3, IsConfirmed = true, CreatedAt = new DateTime(2025, 1, 20) },

                // More comments can be added similarly for other products...
            }
        );
    }
}

}