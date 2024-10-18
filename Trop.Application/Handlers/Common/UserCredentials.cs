namespace Trop.Application.Handlers.Common;

public record struct UserCredentials(Guid Key, string UserName, string Email)
{
    public Guid Key { get; init; } = Key;
    public string UserName { get; init; } = UserName;
    public string Email { get; init; } = Email;
}