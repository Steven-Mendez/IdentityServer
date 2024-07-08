namespace IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetToken.DataTransferObjects;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Represents the data transfer object for an Azure AD token.
/// </summary>
public record AzureAdTokenDto(string access_token);