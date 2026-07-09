namespace Smbs.Domain.Results;

public class PaginatedResult<T>
{
    public List<T> Items { get; set; }
    public int TotalCount { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }

    public PaginatedResult(List<T> items, int count, int page, int pageSize)
    {
        Items = items;
        TotalCount = count;
        CurrentPage = page;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }
}
