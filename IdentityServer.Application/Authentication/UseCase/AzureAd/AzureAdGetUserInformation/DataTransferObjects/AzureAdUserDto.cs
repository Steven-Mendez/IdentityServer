namespace IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation.DataTransferObjects;

public record AzureAdUserDto(
    List<string> businessPhones,
    string displayName,
    string givenName,
    string jobTitle,
    string mail,
    string mobilePhone,
    string officeLocation,
    string preferredLanguage,
    string surname,
    string userPrincipalName,
    string id
);