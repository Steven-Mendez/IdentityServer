namespace IdentityServer.Application.Users.UseCases.UpdateMicrosoftId.DataTransferObjects;

public class UpdateMicrosoftIdResponse
{
    public Guid Id { get; set; }
    public string? MicrosoftId { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Avatar { get; set; }
    public bool IsBlocked { get; set; }
}