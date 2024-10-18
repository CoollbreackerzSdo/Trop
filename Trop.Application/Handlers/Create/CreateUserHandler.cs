using Microsoft.AspNetCore.Identity;

using Trop.Application.Common.Mappers;
using Trop.Application.Common.Repository;
using Trop.Domain.Models.User;

namespace Trop.Application.Handlers.Create;

public class CreateUserHandler(IPasswordHasher<UserEntity> hasher, IUnitOfWord unitOfWord) : IHandlerAsync<CreateUserCommandHandler, UserCredentials>
{
    public async Task<Result<UserCredentials>> HandleAsync(CreateUserCommandHandler request, CancellationToken token)
    {
        if (unitOfWord.UserRepository.GetAll().GroupBy(x => x.Security.Email).Count() >= 10)
            return Result.Forbidden();

        var model = UserMapper.Map(request);
        model.Security.Password = hasher.HashPassword(model, model.Security.Password);
        var credentials = unitOfWord.UserRepository.WithAddMap(model, UserMapper.ToCredentials);

        try
        {
            await unitOfWord.SaveChangesAsync(token);
            return credentials;
        }
        catch (Exception)
        {
            return Result.Conflict();
        }
    }
}

public record struct CreateUserCommandHandler(string UserName, string Email, string Password, string? FirstName = null, string? LastName = null)
{
    public string UserName { get; init; } = UserName;
    public string Email { get; init; } = Email;
    public string Password { get; init; } = Password;
    public string? FirstName { get; init; } = FirstName;
    public string? LastName { get; init; } = LastName;
}