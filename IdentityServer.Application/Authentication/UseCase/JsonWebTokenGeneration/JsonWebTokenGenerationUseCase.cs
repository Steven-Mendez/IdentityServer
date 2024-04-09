using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.Application.Authentication.UseCase.JsonWebTokenGeneration;

public class JsonWebTokenGenerationUseCase(IConfiguration configuration)
{
    private readonly string _issuer = GetValueFromConfiguration(configuration, "JsonWebTokenSettings:Issuer");
    private readonly string _audience = GetValueFromConfiguration(configuration, "JsonWebTokenSettings:Audience");
    private readonly string _signingKey = GetValueFromConfiguration(configuration, "JsonWebTokenSettings:SigningKey");
    private readonly int _expirationMinutes = int.Parse(GetValueFromConfiguration(configuration, "JsonWebTokenSettings:ExpirationMinutes"));

    private static string GetValueFromConfiguration(IConfiguration configuration, string key)
    {
        var value = configuration[key];
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(configuration), $"Configuration value for '{key}' is missing or empty.");
        }
        return value;
    }

    public (string token, int expirationMinutes) Execute(Guid id, string email, string name, string lastName)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, id.ToString()),
            new(JwtRegisteredClaimNames.Email, email),
            new(JwtRegisteredClaimNames.GivenName, name),
            new(JwtRegisteredClaimNames.FamilyName, lastName),
        };
        return GenerateToken(claims, _expirationMinutes);
    }

    private (string token, int expireMinutes) GenerateToken(IEnumerable<Claim> claims, int expirationMinutes)
    {
        var key = new SymmetricSecurityKey(Convert.FromBase64String(_signingKey));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
            signingCredentials: signingCredentials);

        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return (token, expirationMinutes);
    }
}