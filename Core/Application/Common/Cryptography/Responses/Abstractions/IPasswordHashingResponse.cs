namespace Core;

public interface IPasswordHashingResponse : ICryptographyResponse
{
    string ProvidedPassword { get; }
    string HashedPassword { get; }
}