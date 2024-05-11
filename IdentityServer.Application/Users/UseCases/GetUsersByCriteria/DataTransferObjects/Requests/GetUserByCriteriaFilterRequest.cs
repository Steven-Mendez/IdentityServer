namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Requests;

public class GetUserByCriteriaFilterRequest
{
    public Guid? Id { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Avatar { get; set; }
    public bool? IsBlocked { get; set; }
}