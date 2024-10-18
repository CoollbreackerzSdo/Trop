using FluentAssertions;

using Trop.Application.Handlers.Create;
using Trop.Application.Services.Validators;

namespace Trop.Test.Unit.Validators;
public class CreateUserValidatorTest
{
    [Fact]
    public void CreateValidaUser_ReturnTrue()
    {
        var validator = new CreateUserValidator();
        var @new = new CreateUserCommandHandler("Marcos", "cocos@gmail.com", "MINIMO930232kiloc");
        validator.Validate(@new).IsValid.Should().BeTrue();
    }
    [Fact]
    public void CreateInValidaNameUser_ReturnFalse()
    {
        var validator = new CreateUserValidator();
        var @new = new CreateUserCommandHandler("Mas", "cocos@gmail.com", "MINIMO930232kiloc");
        validator.Validate(@new).IsValid.Should().BeFalse();
    }
    [Fact]
    public void CreateInValidaEmailUser_ReturnFalse()
    {
        var validator = new CreateUserValidator();
        var @new = new CreateUserCommandHandler("Marcos", "cocogmail.com", "MINIMO930232kiloc");
        validator.Validate(@new).IsValid.Should().BeFalse();
    }
    [Fact]
    public void CreateInValidaPasswordUser_ReturnFalse()
    {
        var validator = new CreateUserValidator();
        var @new = new CreateUserCommandHandler("Marcos Pelado", "cocog@mail.com", "32kiloc");
        validator.Validate(@new).IsValid.Should().BeFalse();
    }
}