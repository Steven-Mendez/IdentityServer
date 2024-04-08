using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IdentityServer.Application.Authentiacion.UseCase.JsonWebTokenGeneration;

public class JsonWebTokenGenerationUseCase
{
    private readonly string _issuer;
    private readonly string _audience;
    private readonly string _signingKey;
    private readonly int _expirationMinutes;

    public JsonWebTokenGenerationUseCase(IConfiguration configuration)
    {
        var issuer = configuration["JsonWebTokenSettings:Issuer"];

        if (string.IsNullOrWhiteSpace(issuer))
            throw new ArgumentNullException(nameof(issuer));

        var audience = configuration["JsonWebTokenSettings:Audience"];

        if (string.IsNullOrWhiteSpace(audience))
            throw new ArgumentNullException(nameof(audience));

        var signingKey = configuration["JsonWebTokenSettings:SigningKey"];

        if (string.IsNullOrWhiteSpace(signingKey))
            throw new ArgumentNullException(nameof(signingKey));

        var expirationMinutes = configuration["JsonWebTokenSettings:ExpirationMinutes"];

        if (string.IsNullOrWhiteSpace(expirationMinutes))
            throw new ArgumentNullException(nameof(expirationMinutes));

        _issuer = issuer;
        _audience = audience;
        _signingKey = signingKey;
        _expirationMinutes = int.Parse(expirationMinutes);
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