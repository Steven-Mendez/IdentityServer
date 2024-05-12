namespace IdentityServer.Application.Options;

public class JsonWebTokenSettings
{
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
    public string SigningKey { get; init; } = null!;
    public int ExpirationMinutes { get; init; }
}