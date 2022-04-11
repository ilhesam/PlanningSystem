namespace Repository;

public interface IPaginatedList<out T> : IReadOnlyList<T>
{
    long TotalItems { get; }
    long TotalPages { get; }
}

public class PaginatedList<T> : List<T>, IPaginatedList<T>
{
    public PaginatedList(long totalItems, long totalPages)
    {
        TotalItems = totalItems;
        TotalPages = totalPages;
    }

    public virtual long TotalItems { get; }
    public virtual long TotalPages { get; }
}