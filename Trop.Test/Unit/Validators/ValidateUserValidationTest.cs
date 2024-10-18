using FluentAssertions;

using Trop.Application.Handlers.Read;
using Trop.Application.Services.Validators;

namespace Trop.Test.Unit.Validators;

public class ValidateUserValidationTest
{
    [Fact]
    public void InsertEmptyUserName_ReturnFalse()
    {
        var validator = new ValidateUserValidator();
        var userDate = new ValidateUserCommandHandler("","cocacolase32902SDSA");
        validator.Validate(userDate).IsValid.Should().BeFalse();
    }
    [Fact]
    public void InsertValidUserDate_ReturnTrue()
    {
        var validator = new ValidateUserValidator();
        var userDate = new ValidateUserCommandHandler("Carcos","cocacolase32902SDSA");
        validator.Validate(userDate).IsValid.Should().BeTrue();
    }
    [Fact]
    public void InsertEmptyPassword_ReturnFalse()
    {
        var validator = new ValidateUserValidator();
        var userDate = new ValidateUserCommandHandler("Carcos","");
        validator.Validate(userDate).IsValid.Should().BeFalse();
    }
}
