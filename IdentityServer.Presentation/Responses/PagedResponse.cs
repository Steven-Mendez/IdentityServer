namespace IdentityServer.Presentation.Responses;

/// <summary>
///     Represents a paginated response for a collection of items of type <typeparamref name="T" />.
/// </summary>
/// <typeparam name="T">The type of the data in the collection.</typeparam>
public class PagedResponse<T>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PagedResponse{T}" /> class.
    /// </summary>
    /// <param name="data">The collection of data items of type <typeparamref name="T" />.</param>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The size of each page.</param>
    /// <param name="totalRecords">The total number of records in the entire collection.</param>
    /// <param name="endPointUrl">The base URL for the endpoint, used to generate navigation links.</param>
    public PagedResponse(IEnumerable<T> data, int? pageNumber, int? pageSize, int totalRecords, string endPointUrl)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalRecords = totalRecords;
        TotalPages = PageSize.HasValue && PageSize.Value != 0
            ? (int)Math.Ceiling(TotalRecords / (double)PageSize.Value)
            : null;
        HasPrevious = PageNumber.HasValue ? PageNumber.Value > 1 : null;
        HasNext = PageNumber.HasValue && TotalPages.HasValue ? PageNumber.Value < TotalPages.Value : null;
        Previous = HasPrevious.HasValue && HasPrevious.Value
            ? $"{endPointUrl}?PageNumber={PageNumber - 1}&PageSize={PageSize}"
            : null;
        Next = HasNext.HasValue && HasNext.Value
            ? $"{endPointUrl}?PageNumber={PageNumber + 1}&PageSize={PageSize}"
            : null;
    }

    /// <summary>
    ///     Gets the collection of data items.
    /// </summary>
    public IEnumerable<T>? Data { get; init; }

    /// <summary>
    ///     Gets the total number of records in the entire collection.
    /// </summary>
    public int TotalRecords { get; }

    /// <summary>
    ///     Gets the current page number.
    /// </summary>
    public int? PageNumber { get; init; }

    /// <summary>
    ///     Gets the size of each page.
    /// </summary>
    public int? PageSize { get; init; }

    /// <summary>
    ///     Gets the total number of pages.
    /// </summary>
    public int? TotalPages { get; init; }

    /// <summary>
    ///     Gets a value indicating whether there is a previous page.
    /// </summary>
    public bool? HasNext { get; init; }

    /// <summary>
    ///     Gets the URL for the next page, if available.
    /// </summary>
    public string? Next { get; init; }

    /// <summary>
    ///     Gets a value indicating whether there is a next page.
    /// </summary>
    public bool? HasPrevious { get; init; }

    /// <summary>
    ///     Gets the URL for the previous page, if available.
    /// </summary>
    public string? Previous { get; init; }
}