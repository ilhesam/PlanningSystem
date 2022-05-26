namespace Core;

public interface IPaginationRequest : IRequest
{
    IPaginator Paginator { get; set; }
    int Number { get; set; }
    byte Size { get; set; }
}