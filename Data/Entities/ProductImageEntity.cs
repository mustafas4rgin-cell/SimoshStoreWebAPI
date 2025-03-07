
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimoshStore;

namespace App.Data.Entities;

public class ProductImageEntity : EntityBase
{
    public int ProductId { get; set; }
    public string Url { get; set; } = null!;

    // Navigation properties
    public ProductEntity Product { get; set; } = null!;
}

internal class ProductImageEntityConfiguration : IEntityTypeConfiguration<ProductImageEntity>
{
    public void Configure(EntityTypeBuilder<ProductImageEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ProductId).IsRequired();
        builder.Property(e => e.Url).IsRequired();
        builder.Property(e => e.CreatedAt).IsRequired();

        builder.HasOne(d => d.Product)
            .WithMany(p => p.Images)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}

internal class ProductImageEntitySeed : IEntityTypeSeed<ProductImageEntity>
{
    public void SeedData(EntityTypeBuilder<ProductImageEntity> builder)
    {
        builder.HasData(
            new List<ProductImageEntity>
            {
                new() { Id = 1, ProductId = 1, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23), },
                new() { Id = 2, ProductId = 2, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23), },
                new() { Id = 3, ProductId = 3, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23), },
                new() { Id = 4, ProductId = 4, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23), },
                new() { Id = 5, ProductId = 5, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23),},
                new() { Id = 6, ProductId = 6, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23), },
                new() { Id = 7, ProductId = 7, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23), },
                new() { Id = 8, ProductId = 8, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23),},
                new() { Id = 9, ProductId = 9, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23), },
                new() { Id = 10, ProductId = 10, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23),},
                new() { Id = 11, ProductId = 11, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23), },
                new() { Id = 12, ProductId = 12, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23), },
                new() { Id = 13, ProductId = 13, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23), },
                new() { Id = 14, ProductId = 14, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23), },
                new() { Id = 15, ProductId = 15, Url = "https://picsum.photos/1500/1500", CreatedAt =new DateTime(2025, 2, 23),}
            }
        );
    }
}