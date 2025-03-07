
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimoshStore;

namespace App.Data.Entities;

public class UserEntity : EntityBase, IHasEnabled
{
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = default!;
    public int RoleId { get; set; } = 3;
    public bool Enabled { get; set; } = true;
    public string Address{ get; set; } = string.Empty;
    public bool HasSellerRequest { get; set; } = false;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
    public string ResetToken { get; set; } = null!;
    public DateTime ResetTokenExpires { get; set; }

    // Navigation properties
    public RoleEntity Role { get; set; } = null!;
}

internal class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Email).IsRequired().HasMaxLength(256);
        builder.HasIndex(e => e.Email).IsUnique();
        builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
        builder.Property(e => e.RoleId).IsRequired();
        builder.Property(e => e.Enabled).IsRequired();
        builder.Property(e => e.CreatedAt).IsRequired();

        builder.HasOne(d => d.Role)
            .WithMany()
            .HasForeignKey(d => d.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}

internal class UserEntitySeed : IEntityTypeSeed<UserEntity>
{
    public void SeedData(EntityTypeBuilder<UserEntity> builder)
    {
        HashingHelper.CreatePasswordHash("1234", out var passwordHash, out var passwordSalt);
        builder.HasData(
            new UserEntity() { Id = 1, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Antalya, Muratpaşa", FirstName = "admin", LastName = "admin", Email = "mustafas4rgin@gmail.com", Enabled = true, RoleId = 1, Phone = "05341233212", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 2, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "İstanbul, Kadıköy", FirstName = "seller", LastName = "seller", Email = "seller@example.com", Enabled = true, RoleId = 2, Phone = "05555555555", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 3, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Muğla, Marmaris", FirstName = "buyer", LastName = "buyer", Email = "buyer@example.com", Enabled = true, RoleId = 3, Phone = "05333333333", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            
            // 20 buyers with RoleId = 3
            new UserEntity() { Id = 4, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "New York, NY", FirstName = "John", LastName = "Doe", Email = "johndoe1@example.com", Enabled = true, RoleId = 3, Phone = "1234567890", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 5, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Los Angeles, CA", FirstName = "Alice", LastName = "Smith", Email = "alicesmith1@example.com", Enabled = true, RoleId = 3, Phone = "2345678901", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 6, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Chicago, IL", FirstName = "James", LastName = "Brown", Email = "jamesbrown1@example.com", Enabled = true, RoleId = 3, Phone = "3456789012", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 7, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Houston, TX", FirstName = "Linda", LastName = "Johnson", Email = "lindajohnson1@example.com", Enabled = true, RoleId = 3, Phone = "4567890123", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 8, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Phoenix, AZ", FirstName = "Michael", LastName = "Williams", Email = "michaelwilliams1@example.com", Enabled = true, RoleId = 3, Phone = "5678901234", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 9, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Philadelphia, PA", FirstName = "Emily", LastName = "Taylor", Email = "emilytaylor1@example.com", Enabled = true, RoleId = 3, Phone = "6789012345", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 10, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "San Antonio, TX", FirstName = "David", LastName = "Martinez", Email = "davidmartinez1@example.com", Enabled = true, RoleId = 3, Phone = "7890123456", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 11, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "San Diego, CA", FirstName = "Olivia", LastName = "Garcia", Email = "oliviagarcia1@example.com", Enabled = true, RoleId = 3, Phone = "8901234567", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 12, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Dallas, TX", FirstName = "Robert", LastName = "Hernandez", Email = "roberthernandez1@example.com", Enabled = true, RoleId = 3, Phone = "9012345678", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 13, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "San Jose, CA", FirstName = "Sophia", LastName = "Lee", Email = "sophialee1@example.com", Enabled = true, RoleId = 3, Phone = "0123456789", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 14, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Austin, TX", FirstName = "Jack", LastName = "Martinez", Email = "jackmartinez1@example.com", Enabled = true, RoleId = 3, Phone = "1234567891", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 15, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Columbus, OH", FirstName = "Ava", LastName = "Rodriguez", Email = "avarodriguez1@example.com", Enabled = true, RoleId = 3, Phone = "2345678902", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 16, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Indianapolis, IN", FirstName = "Ethan", LastName = "Wilson", Email = "ethanwilson1@example.com", Enabled = true, RoleId = 3, Phone = "3456789013", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 17, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Jacksonville, FL", FirstName = "Isabella", LastName = "Clark", Email = "isabellaclark1@example.com", Enabled = true, RoleId = 3, Phone = "4567890124", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 18, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Fort Worth, TX", FirstName = "Mason", LastName = "Lewis", Email = "masonlewis1@example.com", Enabled = true, RoleId = 3, Phone = "5678901235", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 19, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Charlotte, NC", FirstName = "Charlotte", LastName = "Young", Email = "charlottechristopher1@example.com", Enabled = true, RoleId = 3, Phone = "6789012346", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) },
            new UserEntity() { Id = 20, ResetToken = string.Empty, ResetTokenExpires = DateTime.MinValue, Address = "Detroit, MI", FirstName = "Benjamin", LastName = "King", Email = "benjaminking1@example.com", Enabled = true, RoleId = 3, Phone = "7890123457", PasswordHash = passwordHash, PasswordSalt = passwordSalt, CreatedAt = new DateTime(2025, 2, 23) }
        );
    }
}
