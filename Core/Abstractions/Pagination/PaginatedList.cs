namespace Core;

public interface IPaginatedList<out T> : IReadOnlyList<T>
{
    long TotalItems { get; }
    long TotalPages { get; }
}

public class PaginatedList<T> : List<T>, IPaginatedList<T>
{
    public static IPaginatedList<T> Create(long totalItems, long totalPages, IList<T> list)
    {
        var result = new PaginatedList<T>(totalItems, totalPages);
        result.AddRange(list);
        return result;
    }

    public PaginatedList(long totalItems, long totalPages)
    {
        TotalItems = totalItems;
        TotalPages = totalPages;
    }

    public virtual long TotalItems { get; }
    public virtual long TotalPages { get; }
}