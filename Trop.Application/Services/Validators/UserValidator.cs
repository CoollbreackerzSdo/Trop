using FluentValidation;
using static System.Char;

using Trop.Application.Handlers.Create;

namespace Trop.Application.Services.Validators;

public class UserValidator : AbstractValidator<CreateUserCommandHandler>
{
    public UserValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress();

        RuleFor(x => x.UserName)
            .MinimumLength(10)
            .MaximumLength(100);

        RuleFor(x => x.Password)
            .MinimumLength(8)
            .Must(x => x.Count(IsNumber) >= 2)
            .WithMessage("la contraseña debe contener al menos 2 o mas caracteres numéricos")
            .Must(x => x.Count(IsUpper) >= 4)
            .WithMessage("la contraseña debe contener al menos 4 o mas caracteres mayúsculas");
    }
}