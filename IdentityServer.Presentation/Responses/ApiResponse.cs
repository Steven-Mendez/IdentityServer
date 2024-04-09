namespace IdentityServer.Presentation.Responses;

public static class ApiResponse
{
    public static Response<T> Create<T>(T data)
    {
        return new Response<T>(data);
    }

    public static PagedResponse<T> CreatePaged<T>(IEnumerable<T> data, int pageNumber, int pageSize, int totalCount)
    {
        return new PagedResponse<T>(data, pageNumber, pageSize, totalCount);
    }

    public static ErrorResponse CreateError(Exception exception)
    {
        return new ErrorResponse(exception);
    }
}