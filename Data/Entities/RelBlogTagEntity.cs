using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimoshStore;

namespace App.Data.Entities;

public class RelBlogTagEntity : EntityBase
{
    public int BlogId { get; set; }
    public int TagId { get; set; }

    // Navigation properties
    public BlogEntity Blog { get; set; } = null!;

    public BlogTagEntity Tag { get; set; } = null!;
}

internal class RelBlogTagEntityConfiguration : IEntityTypeConfiguration<RelBlogTagEntity>
{
    public void Configure(EntityTypeBuilder<RelBlogTagEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.BlogId).IsRequired();
        builder.Property(e => e.TagId).IsRequired();
        builder.Property(e => e.CreatedAt).IsRequired();

        builder.HasOne(d => d.Blog)
            .WithMany()
            .HasForeignKey(d => d.BlogId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.Tag)
            .WithMany()
            .HasForeignKey(d => d.TagId)
            .OnDelete(DeleteBehavior.NoAction);

    }
     internal class RelBlogTagEntitySeed : IEntityTypeSeed<RelBlogTagEntity>
    {
        public void SeedData(EntityTypeBuilder<RelBlogTagEntity> builder)
        {
            builder.HasData(
                new RelBlogTagEntity { Id = 1, BlogId = 1, TagId = 1, CreatedAt = new DateTime(2025, 2, 23) },
                new RelBlogTagEntity { Id = 2, BlogId = 1, TagId = 2, CreatedAt = new DateTime(2025, 2, 23) },
                new RelBlogTagEntity { Id = 3, BlogId = 2, TagId = 3, CreatedAt = new DateTime(2025, 2, 23) },
                new RelBlogTagEntity { Id = 4, BlogId = 2, TagId = 4, CreatedAt = new DateTime(2025, 2, 23) },
                new RelBlogTagEntity { Id = 5, BlogId = 3, TagId = 5, CreatedAt = new DateTime(2025, 2, 23) },
                new RelBlogTagEntity { Id = 6, BlogId = 3, TagId = 6, CreatedAt = new DateTime(2025, 2, 23) }
            );
        }
    }
}