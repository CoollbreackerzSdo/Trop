using FluentValidation;

using Trop.Application.Handlers.Read;

namespace Trop.Application.Services.Validators;

public class ValidateUserValidator : AbstractValidator<ValidateUserCommandHandler>
{
    public ValidateUserValidator()
    {
        RuleFor(x => x.UserName).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}