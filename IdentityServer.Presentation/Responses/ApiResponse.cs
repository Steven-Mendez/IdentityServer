namespace IdentityServer.Presentation.Responses;

/// <summary>
/// Provides factory methods for creating various types of API responses.
/// </summary>
public static class ApiResponse
{
    /// <summary>
    /// Creates a generic response object with the provided data.
    /// </summary>
    /// <typeparam name="T">The type of the data to be included in the response.</typeparam>
    /// <param name="data">The data to include in the response.</param>
    /// <returns>A <see cref="Response{T}"/> object containing the provided data.</returns>
    public static Response<T> Create<T>(T data)
    {
        return new Response<T>(data);
    }

    /// <summary>
    /// Creates a paged response object for collections, including pagination details.
    /// </summary>
    /// <typeparam name="T">The type of the data in the collection.</typeparam>
    /// <param name="data">The collection of data items.</param>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="totalCount">The total count of items across all pages.</param>
    /// <param name="endPointUrl">The endpoint URL for fetching the paged data.</param>
    /// <returns>A <see cref="PagedResponse{T}"/> object containing the provided data and pagination details.</returns>
    public static PagedResponse<T> CreatePaged<T>(IEnumerable<T> data, int? pageNumber, int? pageSize, int totalCount,
        string endPointUrl)
    {
        return new PagedResponse<T>(data, pageNumber, pageSize, totalCount, endPointUrl);
    }

    /// <summary>
    /// Creates an error response object based on the provided exception.
    /// </summary>
    /// <param name="exception">The exception to base the error response on.</param>
    /// <returns>An <see cref="ErrorResponse"/> object containing details about the exception.</returns>
    public static ErrorResponse CreateError(Exception exception)
    {
        return new ErrorResponse(exception);
    }
}