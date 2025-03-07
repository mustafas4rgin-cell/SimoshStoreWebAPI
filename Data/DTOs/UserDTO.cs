using System.ComponentModel.DataAnnotations;

namespace SimoshStore;

public class UserDTO
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Password { get; set; } = default!;
    public int RoleId { get; set; } = default!;
}