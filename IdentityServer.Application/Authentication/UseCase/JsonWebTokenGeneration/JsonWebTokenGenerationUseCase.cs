using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IdentityServer.Application.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.Application.Authentication.UseCase.JsonWebTokenGeneration;

public class JsonWebTokenGenerationUseCase(IOptions<JsonWebTokenSettings> options)
{
    private readonly string _audience = options.Value.Audience;
    private readonly int _expirationMinutes = options.Value.ExpirationMinutes;
    private readonly string _issuer = options.Value.Issuer;
    private readonly string _sigIngKey = options.Value.SigningKey;

    public (string token, int expirationMinutes) Execute(Guid id, string email, string name, string lastName)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, id.ToString()),
            new(JwtRegisteredClaimNames.Email, email),
            new(JwtRegisteredClaimNames.GivenName, name),
            new(JwtRegisteredClaimNames.FamilyName, lastName)
        };
        return GenerateToken(claims);
    }

    private (string token, int expireMinutes) GenerateToken(IEnumerable<Claim> claims)
    {
        var settings = options.Value;

        var key = new SymmetricSecurityKey(Convert.FromBase64String(_sigIngKey));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            _issuer,
            _audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(_expirationMinutes),
            signingCredentials: signingCredentials);

        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return (token, settings.ExpirationMinutes);
    }
}