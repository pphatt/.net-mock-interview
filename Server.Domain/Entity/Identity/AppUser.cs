using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Domain.Entity.Identity;

[Table("AppUsers")]
public class AppUser : BaseEntity // IdentityUser<Guid>
{
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required]
    public string Username { get; set; } = default!;

    [Required]
    public DateTime Dob { get; set; }
}
