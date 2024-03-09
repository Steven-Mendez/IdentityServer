namespace IdentityServer.Application.Users.UseCases.SoftDeleteUser.DTO.Response;

public class SoftDeleteUserResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Avatar { get; set; }
    public bool IsDeleted { get; set; }
}