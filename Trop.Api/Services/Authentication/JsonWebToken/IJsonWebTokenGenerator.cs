using System.Security.Claims;

namespace Trop.Api.Services.Authentication.JsonWebToken;

public interface IJsonWebTokenGenerator
{
    string GenerateToken(IEnumerable<Claim> claims);
}