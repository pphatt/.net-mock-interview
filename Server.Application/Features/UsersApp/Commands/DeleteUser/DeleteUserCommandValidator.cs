using FluentValidation;

namespace Server.Application.Features.UsersApp.Commands.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
    }
}
