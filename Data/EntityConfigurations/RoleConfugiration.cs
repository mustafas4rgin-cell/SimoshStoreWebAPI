using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimoshStore;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {

        builder.HasKey(r => r.Id); // Primary key

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(50); // Name alanı zorunlu ve maksimum 50 karakter

        // Role ile UserRole arasındaki ilişki
        builder.HasMany(r => r.UserRoles)
            .WithOne(ur => ur.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
    }
}
