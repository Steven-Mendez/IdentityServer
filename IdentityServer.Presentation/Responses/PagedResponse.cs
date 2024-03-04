namespace IdentityServer.Presentation.Responses;

public class PagedResponse<T>
{
    const int MaxPageSize = 50;

    public List<T>? Data { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    public PagedResponse(List<T> data, int pageNumber, int pageSize, int totalCount)
    {
        if (pageNumber < 1)
            throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number cannot be less than 1.");

        if (pageSize < 1)
            throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size cannot be less than 1.");

        if (totalCount < 1)
            throw new ArgumentOutOfRangeException(nameof(totalCount), "Total count cannot be less than 1.");

        if (pageSize > MaxPageSize)
            throw new ArgumentOutOfRangeException(nameof(pageSize), $"Page size cannot be greater than {MaxPageSize}.");

        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
    }
}
