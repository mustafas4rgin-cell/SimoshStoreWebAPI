
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimoshStore;

namespace App.Data.Entities;

public class RelBlogCategoryEntity : EntityBase
{
    public int BlogId { get; set; }
    public int CategoryId { get; set; }

    // Navigation properties
    public BlogEntity Blog { get; set; } = null!;

    public BlogCategoryEntity Category { get; set; } = null!;
}

internal class RelBlogCategoryEntityConfiguration : IEntityTypeConfiguration<RelBlogCategoryEntity>
{
    public void Configure(EntityTypeBuilder<RelBlogCategoryEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.BlogId).IsRequired();
        builder.Property(e => e.CategoryId).IsRequired();
        builder.Property(e => e.CreatedAt).IsRequired();
        builder.HasIndex(e => new { e.BlogId, e.CategoryId }).IsUnique(); // Each blog and category pair should be unique

        builder.HasOne(d => d.Blog)
            .WithMany()
            .HasForeignKey(d => d.BlogId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.Category)
            .WithMany(bc => bc.BlogRelations)
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}

internal class RelBlogCategoryEntitySeed : IEntityTypeSeed<RelBlogCategoryEntity>
{
    public void SeedData(EntityTypeBuilder<RelBlogCategoryEntity> builder)
    {
        builder.HasData(new List<RelBlogCategoryEntity>() {
            new () { Id = 1, BlogId = 1, CategoryId = 2, CreatedAt = new DateTime(2025, 2, 23) },
            new () { Id = 2, BlogId = 1, CategoryId = 4, CreatedAt = new DateTime(2025, 2, 23) },
            new () { Id = 3, BlogId = 2, CategoryId = 2, CreatedAt = new DateTime(2025, 2, 23) },
            new () { Id = 4, BlogId = 2, CategoryId = 3, CreatedAt = new DateTime(2025, 2, 23) },
            new () { Id = 5, BlogId = 3, CategoryId = 2, CreatedAt = new DateTime(2025, 2, 23) },
            new () { Id = 6, BlogId = 4, CategoryId = 2, CreatedAt = new DateTime(2025, 2, 23) },
            new () { Id = 7, BlogId = 5, CategoryId = 2, CreatedAt = new DateTime(2025, 2, 23) },
            new () { Id = 8, BlogId = 6, CategoryId = 2, CreatedAt = new DateTime(2025, 2, 23) },
            new () { Id = 9, BlogId = 7, CategoryId = 2, CreatedAt = new DateTime(2025, 2, 23) },
        });
    }
}