namespace IdentityServer.Application.Options;

public class AzureAdSettings
{
    public string ClientId { get; init; } = null!;
    public string TenantId { get; init; } = null!;
}