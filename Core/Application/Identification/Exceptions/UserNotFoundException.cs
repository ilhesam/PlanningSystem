namespace Core.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("User not found")
    {
        Data.Add("Code", "NOT_FOUND");
    }
}