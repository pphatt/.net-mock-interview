namespace Server.Application.Common.Dtos.Users;

public class UserDto
{
    public Guid Id { get; set; }

    public string Email { get; set; } = default!;

    public string Username { get; set; } = default!;

    public DateTime Dob { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public DateTime? DateDeleted { get; set; }
}
