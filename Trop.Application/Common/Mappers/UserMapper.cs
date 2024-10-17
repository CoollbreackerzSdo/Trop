using Riok.Mapperly.Abstractions;

using Trop.Application.Handlers.Create;
using Trop.Domain.Models.User;

namespace Trop.Application.Common.Mappers;
[Mapper(EnumMappingIgnoreCase = true, EnumMappingStrategy = EnumMappingStrategy.ByValueCheckDefined, IgnoreObsoleteMembersStrategy = IgnoreObsoleteMembersStrategy.Both, EnabledConversions = MappingConversionType.All)]
public static partial class UserMapper
{
    public static UserEntity Map(CreateUserCommandHandler command)
        => UserEntity.Create(userName: command.UserName, security: new UserSecurity { Email = command.Password, Password = command.Password }, creation: DateTimeOffset.UtcNow.DateTime, detail: new() { FirstName = command.FirstName, LastName = command.LastName });
    [MapProperty(nameof(UserEntity.UserName), nameof(UserView.UserName))]
    [MapProperty([nameof(UserEntity.Security), nameof(UserEntity.Security.Email)], nameof(UserView.Email))]
    [MapPropertyFromSource([nameof(UserView.Register)], Use = nameof(ConstructUtcDateTime))]
    public static partial UserView ToView(UserEntity entity);
    [MapProperty(nameof(UserEntity.UserName), nameof(UserCredentials.UserName))]
    [MapProperty([nameof(UserEntity.Security), nameof(UserEntity.Security.Email)], nameof(UserCredentials.Email))]
    public static partial UserCredentials ToCredentials(UserEntity entity);
    private static DateTime ConstructUtcDateTime(UserEntity entity) => entity.RegisterDateAtUtc.ToDateTime(entity.RegisterTimeAtUtc);
}