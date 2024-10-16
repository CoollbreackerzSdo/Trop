using System.Diagnostics.CodeAnalysis;

using Trop.Domain.Common;

namespace Trop.Domain.Models.User;

public class UserEntity : EntityBase, IRegister
{
    internal UserEntity() { }
    [SetsRequiredMembers]
    public UserEntity(UserEntity modelToCopy)
        => (Key, UserName, Security, Detail, Rol, RegisterDateAtUtc, RegisterTimeAtUtc) = (modelToCopy.Key, modelToCopy.UserName, modelToCopy.Security, modelToCopy.Detail, modelToCopy.Rol, modelToCopy.RegisterDateAtUtc, modelToCopy.RegisterTimeAtUtc);
    public static UserEntity Create(string userName, UserSecurity security, DateTime creation, UserRoles rol = UserRoles.Normal, UserDetail? detail = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(userName);
        ArgumentNullException.ThrowIfNull(security, paramName: nameof(security));
        return new()
        {
            UserName = userName,
            Security = security,
            Rol = rol,
            Detail = detail,
            RegisterDateAtUtc = DateOnly.FromDateTime(creation),
            RegisterTimeAtUtc = TimeOnly.FromDateTime(creation)
        };
    }
    public required string UserName { get; set; }
    public required UserRoles Rol { get; init; }
    public required UserSecurity Security { get; set; }
    public UserDetail? Detail { get; init; }
    public DateOnly RegisterDateAtUtc { get; init; }
    public TimeOnly RegisterTimeAtUtc { get; init; }
}

public class UserSecurity
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
public class UserDetail
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

public enum UserRoles
{
    Admin,
    Normal,
    None
}