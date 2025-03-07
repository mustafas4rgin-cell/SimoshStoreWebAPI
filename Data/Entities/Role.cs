namespace SimoshStore;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public virtual ICollection<UserRole> UserRoles { get; set; } = default!;
}


