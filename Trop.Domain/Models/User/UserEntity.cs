using System.Diagnostics.CodeAnalysis;

using Trop.Domain.Common;

namespace Trop.Domain.Models.User;

public class UserEntity : EntityBase, IRegister
{
    internal UserEntity() { }
    [SetsRequiredMembers]
    public UserEntity(UserEntity modelToCopy)
        => (Key, UserName, Security, Detail, RegisterDateAtUtc, RegisterTimeAtUtc) = (modelToCopy.Key, modelToCopy.UserName, modelToCopy.Security, modelToCopy.Detail, modelToCopy.RegisterDateAtUtc, modelToCopy.RegisterTimeAtUtc);
    public static UserEntity Create(string userName, UserSecurity security, DateTime creation, UserDetail? detail = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(userName);
        ArgumentNullException.ThrowIfNull(security, paramName: nameof(security));
        return new()
        {
            UserName = userName,
            Security = security,
            Detail = detail,
            RegisterDateAtUtc = DateOnly.FromDateTime(creation),
            RegisterTimeAtUtc = TimeOnly.FromDateTime(creation)
        };
    }
    public required string UserName { get; set; }
    public required UserSecurity Security { get; set; }
    public UserDetail? Detail { get; init; }
    public DateOnly RegisterDateAtUtc { get; init; }
    public TimeOnly RegisterTimeAtUtc { get; init; }
}

public class UserSecurity
{
    public UserSecurity() { }
    [SetsRequiredMembers]
    public UserSecurity(UserSecurity copy)
        => (Email, Password) = (copy.Email, copy.Password);
    public required string Email { get; set; }
    public required string Password { get; set; }
}
public class UserDetail
{
    public UserDetail() { }
    [SetsRequiredMembers]
    public UserDetail(UserDetail copy)
        => (FirstName, LastName) = (copy.FirstName, copy.LastName);
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}