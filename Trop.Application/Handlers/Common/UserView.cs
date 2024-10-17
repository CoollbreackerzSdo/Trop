namespace Trop.Application.Handlers.Common;

public record struct UserView(string UserName, string Email, DateTime Register)
{
    public string UserName { get; init; } = UserName;
    public string Email { get; init; } = Email;
    public DateTime Register { get; init; } = Register;
}

public record UserCredentials(string UserName, string Email);