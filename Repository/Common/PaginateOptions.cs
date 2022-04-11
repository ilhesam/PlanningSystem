namespace Repository;

public class PaginateOptions
{
    public PaginateOptions(int number = 1, int size = 10)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException(nameof(number));
        if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));

        Number = number;
        Size = size;
    }

    public int Number { get; }
    public int Size { get; }
}