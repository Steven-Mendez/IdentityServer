namespace IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation.DataTransferObjects;

/// <summary>
/// Represents the data transfer object for a user's information obtained from Azure AD.
/// </summary>
/// <param name="businessPhones">The list of business phone numbers associated with the user.</param>
/// <param name="displayName">The display name of the user.</param>
/// <param name="givenName">The given name (first name) of the user.</param>
/// <param name="jobTitle">The job title of the user.</param>
/// <param name="mail">The primary email address of the user.</param>
/// <param name="mobilePhone">The mobile phone number of the user.</param>
/// <param name="officeLocation">The office location of the user.</param>
/// <param name="preferredLanguage">The preferred language of the user.</param>
/// <param name="surname">The surname (last name) of the user.</param>
/// <param name="userPrincipalName">The user principal name (UPN) of the user, which is used to log in to Azure AD.</param>
/// <param name="id">The unique identifier of the user in Azure AD.</param>
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