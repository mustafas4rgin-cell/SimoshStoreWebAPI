using System.ComponentModel.DataAnnotations;

namespace SimoshStore;

public class RegisterDto
{
    [Required]
    public string FirstName { get; set; } = default!;
    [Required]
    public string LastName { get; set; } = default!;
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; } = default!;
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;
}
