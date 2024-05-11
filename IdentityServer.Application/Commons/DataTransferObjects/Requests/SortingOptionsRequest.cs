namespace IdentityServer.Application.Commons.DataTransferObjects.Requests;

public class SortingOptionsRequest
{
    public string? OrderBy { get; set; }
    public string? OrderType { get; set; }
}