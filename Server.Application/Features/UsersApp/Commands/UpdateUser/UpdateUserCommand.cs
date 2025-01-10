using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Server.Application.Features.UsersApp.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public Guid Id { get; set; }

    public string Username { get; set; } = default!;

    public DateTime Dob { get; set; }
}
