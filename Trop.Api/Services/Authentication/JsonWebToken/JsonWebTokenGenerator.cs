using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Trop.Api.Services.Authentication.JsonWebToken;

public class JsonWebTokenGenerator(IOptions<JsonWebTokenSettings> options) : IJsonWebTokenGenerator
{
    public string GenerateToken(IEnumerable<Claim> claims)
        => new JwtSecurityTokenHandler()
            .WriteToken(new JwtSecurityToken(
                claims: claims,
                expires: DateTimeOffset.UtcNow.AddDays(_settings.ExpirationDays).DateTime,
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key)), 
                    SecurityAlgorithms.HmacSha256Signature)
                )
            );
    private readonly JsonWebTokenSettings _settings = options.Value;
}