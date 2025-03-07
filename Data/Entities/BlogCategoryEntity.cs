
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimoshStore;

namespace App.Data.Entities;

public class BlogCategoryEntity : EntityBase
{
    public string Name { get; set; } = null!;

    // Navigation properties
    public ICollection<RelBlogCategoryEntity> BlogRelations { get; set; } = [];
}

internal class BlogCategoryEntityConfiguration : IEntityTypeConfiguration<BlogCategoryEntity>
{
    public void Configure(EntityTypeBuilder<BlogCategoryEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
        builder.Property(e => e.CreatedAt).IsRequired();

    }
}

internal class BlogCategoryEntitySeed : IEntityTypeSeed<BlogCategoryEntity>
{
    public void SeedData(EntityTypeBuilder<BlogCategoryEntity> builder)
    {
        builder.HasData(new List<BlogCategoryEntity> {
            new() { Id = 1, Name = "Beauty", CreatedAt = new DateTime(2025, 2, 23)},
            new() { Id = 2, Name = "Food", CreatedAt = new DateTime(2025, 2, 23)},
            new() { Id = 3, Name = "Life Style", CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 4, Name = "Travel", CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 5, Name = "Fashion", CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 7, Name = "Education", CreatedAt = new DateTime(2025, 2, 23)},
            new() { Id = 8, Name = "Entertainment", CreatedAt = new DateTime(2025, 2, 23) },
            new() { Id = 9, Name = "Sports", CreatedAt = new DateTime(2025, 2, 23) }
        });
    }
}