namespace SimoshStore;

public class User 
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Email { get; set; } = default!;
    public int RoleId { get; set; } = 3;
    public byte[] PasswordHash { get; set; } = default!;
    public byte[] PasswordSalt { get; set; } = default!;

    //navigation property
    public virtual ICollection<UserRole> UserRoles { get; set; } = default!;
}