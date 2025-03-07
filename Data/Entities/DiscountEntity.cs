
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimoshStore;

namespace App.Data.Entities
{
    public class DiscountEntity : EntityBase, IHasEnabled
    {
        public byte DiscountRate { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public bool Enabled { get; set; } = true;
    }

    internal class DiscountEntityConfiguration : IEntityTypeConfiguration<DiscountEntity>
    {
        public void Configure(EntityTypeBuilder<DiscountEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Enabled).IsRequired();
            builder.Property(e => e.CreatedAt).IsRequired();

        }
    }

    internal class DiscountEntitySeed : IEntityTypeSeed<DiscountEntity>
    {
        public void SeedData(EntityTypeBuilder<DiscountEntity> builder)
        {
            builder.HasData(
                new List<DiscountEntity>
                {
                    new() { Id = 1, DiscountRate = 10, StartDate = new DateTime(2025, 2, 23), EndDate =new DateTime(2025, 2, 23).AddMonths(6), Enabled = true, CreatedAt = new DateTime(2025, 2, 23) },
                    new() { Id = 2, DiscountRate = 20, StartDate = new DateTime(2025, 2, 23), EndDate =new DateTime(2025, 2, 23).AddMonths(6), Enabled = true, CreatedAt = new DateTime(2025, 2, 23)},
                    new() { Id = 3, DiscountRate = 30, StartDate = new DateTime(2025, 2, 23), EndDate =new DateTime(2025, 2, 23).AddMonths(6), Enabled = true, CreatedAt = new DateTime(2025, 2, 23) }
                }
            );
        }
    }
}