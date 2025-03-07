using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimoshStore;

namespace App.Data.Entities;

public class OrderItemEntity : EntityBase
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    // Navigation properties
    public OrderEntity Order { get; set; } = null!;

    public ProductEntity Product { get; set; } = null!;
}

internal class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItemEntity>
{
    public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.OrderId).IsRequired();
        builder.Property(e => e.ProductId).IsRequired();
        builder.Property(e => e.Quantity).IsRequired(); // 1 item by default
        builder.Property(e => e.UnitPrice).IsRequired();
        builder.Property(e => e.CreatedAt).IsRequired();

        builder.HasIndex(e => new { e.OrderId, e.ProductId }).IsUnique(); // Each product can be added only once to an order

        builder.HasOne(d => d.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Product)
            .WithMany()
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

    }
    internal class OrderItemEntitySeed : IEntityTypeSeed<OrderItemEntity>
    {
        public void SeedData(EntityTypeBuilder<OrderItemEntity> builder)
    {
        builder.HasData(new List<OrderItemEntity>() {
            new () {  Id = 1, OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 100, CreatedAt = new DateTime(2025, 1, 1) },
            new () {  Id = 2, OrderId = 1, ProductId = 2, Quantity = 1, UnitPrice = 200, CreatedAt = new DateTime(2025, 1, 1) },
            new () { Id = 3,  OrderId = 2, ProductId = 3, Quantity = 1, UnitPrice = 150, CreatedAt = new DateTime(2025, 1, 2) },
            new () {  Id = 4, OrderId = 3, ProductId = 4, Quantity = 3, UnitPrice = 50, CreatedAt = new DateTime(2025, 1, 3) },
            new () { Id = 5,  OrderId = 4, ProductId = 5, Quantity = 1, UnitPrice = 300, CreatedAt = new DateTime(2025, 1, 4) },
            new () {  Id = 6, OrderId = 5, ProductId = 6, Quantity = 2, UnitPrice = 100, CreatedAt = new DateTime(2025, 1, 5) },
            new () { Id = 7,  OrderId = 6, ProductId = 7, Quantity = 1, UnitPrice = 200, CreatedAt = new DateTime(2025, 1, 6) },
            new () {  Id = 8, OrderId = 7, ProductId = 8, Quantity = 1, UnitPrice = 150, CreatedAt = new DateTime(2025, 1, 7) },
            new () { Id = 9,  OrderId = 8, ProductId = 9, Quantity = 3, UnitPrice = 50, CreatedAt = new DateTime(2025, 1, 8) },
            new () { Id = 10,  OrderId = 9, ProductId = 10, Quantity = 1, UnitPrice = 300, CreatedAt = new DateTime(2025, 1, 9) },
        });
    }
    }
    
}