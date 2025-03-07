
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimoshStore;

namespace App.Data.Entities;

public class RoleEntity : EntityBase
{
    public string Name { get; set; } = null!;
}

internal class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(10);
        builder.Property(e => e.CreatedAt).IsRequired();

    }
}

internal class RoleEntitySeed : IEntityTypeSeed<RoleEntity>
{
    public void SeedData(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.HasData(
            new RoleEntity() { Id = 1, Name = "admin", CreatedAt =new DateTime(2025, 2, 23), },
            new RoleEntity() { Id = 2, Name = "seller", CreatedAt =new DateTime(2025, 2, 23), },
            new RoleEntity() { Id = 3, Name = "buyer", CreatedAt =new DateTime(2025, 2, 23), }
        );
    }
}