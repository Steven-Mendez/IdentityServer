namespace IdentityServer.Application.Options;

public class AzureAdSettings
{
    public string ClientId { get; init; } = null!;
    public string TenantId { get; init; } = null!;
    public string ClientSecret { get; init; } = null!;
    public string RedirectUrl { get; init; } = null;
}