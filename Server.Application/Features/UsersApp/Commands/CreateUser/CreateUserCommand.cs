using MediatR;

namespace Server.Application.Features.UsersApp.Commands.CreateUser;

public class CreateUserCommand : IRequest
{
    public string Email { get; set; } = default!;
    public string Username { get; set; } = default!;
    public DateTime Dob { get; set; }
}
