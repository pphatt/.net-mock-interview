using MediatR;

namespace Server.Application.Features.UsersApp.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public Guid Id { get; set; }
}
