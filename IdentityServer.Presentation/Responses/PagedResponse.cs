namespace IdentityServer.Presentation.Responses;

public class PagedResponse<T>
{
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
        Previous = HasPrevious.HasValue && HasPrevious.Value ? endPointUrl : null;
        Next = HasNext.HasValue && HasNext.Value ? endPointUrl : null;
    }

    public IEnumerable<T>? Data { get; init; }
    public int? PageNumber { get; init; }
    public int? PageSize { get; init; }
    public int TotalRecords { get; }
    public int? TotalPages { get; init; }
    public bool? HasPrevious { get; init; }
    public bool? HasNext { get; init; }
    public string? Previous { get; init; }
    public string? Next { get; init; }
}