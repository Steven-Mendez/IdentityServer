namespace IdentityServer.Application.Commons.DataTransferObjects.Requests;

public class PaginationOptionsRequest
{
    public int? PageNumber { get; init; }
    public int? PageSize { get; init; }
}