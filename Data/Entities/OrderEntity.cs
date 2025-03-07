using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimoshStore;

namespace App.Data.Entities;

public class OrderEntity : EntityBase
{
    public int UserId { get; set; }
    public string OrderCode { get; set; } = null!;
    public string Address { get; set; } = null!;

    // Navigation properties
    public UserEntity User { get; set; } = null!;

    public ICollection<OrderItemEntity> OrderItems { get; set; } = [];
}

internal class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.OrderCode).IsRequired().HasMaxLength(250);
        builder.Property(e => e.Address).IsRequired().HasMaxLength(250);
        builder.Property(e => e.CreatedAt).IsRequired();

        builder.HasIndex(e => e.OrderCode).IsUnique();

        builder.HasOne(d => d.User)
            .WithMany()
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}

internal class OrderEntitySeed : IEntityTypeSeed<OrderEntity>
{
    public void SeedData(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.HasData(new List<OrderEntity>() {
            new () { Id = 1, Address = "Antalya", OrderCode = "ORD-1", UserId = 1, CreatedAt = new DateTime(2025, 1, 1) },
            new () { Id = 2, Address = "Istanbul", OrderCode = "ORD-2", UserId = 2, CreatedAt = new DateTime(2025, 1, 2) },
            new () { Id = 3, Address = "Ankara", OrderCode = "ORD-3", UserId = 3, CreatedAt = new DateTime(2025, 1, 3) },
            new () { Id = 4, Address = "Izmir", OrderCode = "ORD-4", UserId = 1, CreatedAt = new DateTime(2025, 1, 4) },
            new () { Id = 5, Address = "Bursa", OrderCode = "ORD-5", UserId = 1, CreatedAt = new DateTime(2025, 1, 5) },
            new () {  Id = 6,Address = "Adana", OrderCode = "ORD-6", UserId = 3, CreatedAt = new DateTime(2025, 1, 6) },
            new () { Id = 7, Address = "Trabzon", OrderCode = "ORD-7", UserId = 3, CreatedAt = new DateTime(2025, 1, 7) },
            new () {  Id = 8,Address = "Samsun", OrderCode = "ORD-8", UserId = 3, CreatedAt = new DateTime(2025, 1, 8) },
            new () {  Id = 9 ,Address = "Mersin", OrderCode = "ORD-9", UserId = 3, CreatedAt = new DateTime(2025, 1, 9) },
        });
    }
}