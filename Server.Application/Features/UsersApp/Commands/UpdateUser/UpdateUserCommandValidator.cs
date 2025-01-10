using FluentValidation;

namespace Server.Application.Features.UsersApp.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator() 
    {
        RuleFor(dto => dto.Username)
            .NotNull();

        RuleFor(dto => dto.Dob)
            .Must(dob => dob <= DateTime.UtcNow.AddYears(-18))
            .WithMessage("User's age have to be atleast 18")
            .NotEmpty()
            .NotNull();
    }
}
