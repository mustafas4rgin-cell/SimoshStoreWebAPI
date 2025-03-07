
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimoshStore;

namespace App.Data.Entities;

public class CategoryEntity : EntityBase
{
    public string Name { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string IconCssClass { get; set; } = null!;
    public string imageUrl { get; set; } = null!;
}

internal class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Color).IsRequired();
        builder.Property(e => e.IconCssClass).IsRequired().HasMaxLength(50);
        builder.Property(e => e.CreatedAt).IsRequired();

    }
}

internal class CategoryEntitySeed : IEntityTypeSeed<CategoryEntity>
{
    public void SeedData(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.HasData(
            new List<CategoryEntity>{
                new() { Id = 1, Name = "Fresh Meat", Color = "Blue", IconCssClass = string.Empty, CreatedAt = new DateTime(2025, 2, 23), imageUrl="/images/category/category-1.jpg" },
                new() { Id = 2, Name = "Vegetables", Color = "Red", IconCssClass = string.Empty, CreatedAt = new DateTime(2025, 2, 23) , imageUrl="/images/category/category-2.jpg"},
                new() { Id = 3, Name = "Fresh Fruits", Color = "Green", IconCssClass = string.Empty, CreatedAt = new DateTime(2025, 2, 23) , imageUrl="/images/category/category-3.jpg"},
                new() { Id = 4, Name = "Dried Fruits & Nuts", Color = "Brown", IconCssClass = string.Empty, CreatedAt = new DateTime(2025, 2, 23), imageUrl="/images/category/category-4.jpg" },
                new() { Id = 5, Name = "Ocean Foods", Color = "Purple", IconCssClass = string.Empty, CreatedAt = new DateTime(2025, 2, 23), imageUrl="/images/category/category-5.jpg" },
                new() { Id = 6, Name = "Butter & Eggs", Color = "Yellow", IconCssClass = string.Empty, CreatedAt = new DateTime(2025, 2, 23),imageUrl="/images/category/category-6.jpg" },
                new() { Id = 7, Name = "Fastfood", Color = "Pink", IconCssClass = string.Empty, CreatedAt = new DateTime(2025, 2, 23), imageUrl="/images/category/category-7.jpg" },
                new() { Id = 8, Name = "Oatmeal", Color = "Grey", IconCssClass = string.Empty, CreatedAt = new DateTime(2025, 2, 23), imageUrl="/images/category/category-8.jpg" },
                new() { Id = 9, Name = "Juices", Color = "Orange", IconCssClass = string.Empty, CreatedAt = new DateTime(2025, 2, 23), imageUrl="/images/category/category-9.jpg" }
            }
        );
    }
}