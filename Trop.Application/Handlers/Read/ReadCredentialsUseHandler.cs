
using Microsoft.AspNetCore.Identity;

using Trop.Application.Common.Repository;
using Trop.Domain.Models.User;

namespace Trop.Application.Handlers.Read;

public class ReadCredentialsUseHandler(IPasswordHasher<UserEntity> hasher, IUnitOfWord unitOfWord) : IHandler<ValidateUserCommandHandler, UserCredentials>
{
    public Result<UserCredentials> Handle(ValidateUserCommandHandler request)
    {
        var user = unitOfWord.UserRepository.GetAll().Where(x => x.UserName == request.UserName)
            .Select(x => new { x.Key, x.UserName, x.Security.Email, x.Security.Password }).SingleOrDefault();

        if (user is null) return Result.NotFound();

        return hasher.VerifyHashedPassword(null!, user.Password, request.Password) == PasswordVerificationResult.Success
            ? Result.Success(new UserCredentials(user.Key, user.UserName, user.Email))
            : Result.Invalid();
    }
}

public record struct ValidateUserCommandHandler(string UserName, string Password)
{
    public string UserName { get; init; } = UserName;
    public string Password { get; init; } = Password;
}