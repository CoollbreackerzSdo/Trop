namespace Trop.Api.Services.Authentication.JsonWebToken;

public class JsonWebTokenSettings
{
    public required string Key { get; init; }
    public required string Author { get; init; }
    public required string Audience { get; init; }
    public required int ExpirationDays { get; init; }
    public required string Issuer { get; init; }
}