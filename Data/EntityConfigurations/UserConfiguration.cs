using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimoshStore;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.HasKey(u => u.Id); // Primary key

        builder.HasIndex(u => u.Email).IsUnique(); // Email alanı unique olmalı

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255); // Email alanı zorunlu ve maksimum 255 karakter

        builder.Property(u => u.PasswordHash).IsRequired(); // Password Hash alanı zorunlu ve maksimum 255 karakter

        builder.Property(u => u.PasswordSalt).IsRequired(); // Password Salt alanı zorunlu ve maksimum 255 karakter

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(100); // FirstName alanı zorunlu ve maksimum 100 karakter

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(100); // LastName alanı zorunlu ve maksimum 100 karakter

        builder.Property(u => u.Phone)
            .HasMaxLength(20); // Phone alanı maksimum 20 karakter

        // User ile UserRole arasındaki ilişki
        builder.HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
    }
}
