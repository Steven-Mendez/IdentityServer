using IdentityServer.Application.Commons.DataTransferObjects.Requests;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Requests;

public class GetUsersByCriteriaRequest(
    GetUserByCriteriaFilterRequest filter,
    SortingOptionsRequest sortingOptions,
    PaginationOptionsRequest paginationOptions)
{
    public GetUserByCriteriaFilterRequest Filter { get; } = filter;

    public SortingOptionsRequest SortingOptions { get; } = sortingOptions;

    public PaginationOptionsRequest PaginationOptions { get; } = paginationOptions;
}