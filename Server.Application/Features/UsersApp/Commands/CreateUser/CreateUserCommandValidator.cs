using FluentValidation;

namespace Server.Application.Features.UsersApp.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(dto => dto.Email)
            .EmailAddress()
            .NotEmpty()
            .NotNull();

        RuleFor(dto => dto.Username)
            .NotNull()
            .NotEmpty();

        RuleFor(dto => dto.Dob)
            .Must(dob => dob <= DateTime.UtcNow.AddYears(-18))
            .WithMessage("User's age have to be atleast 18")
            .NotNull()
            .NotEmpty();
    }
}
