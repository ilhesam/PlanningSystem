namespace Core;

public interface IPaginationRequest
{
    int Number { get; set; }
    byte Size { get; set; }
}