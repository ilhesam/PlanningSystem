namespace Core;

public class BasePasswordHashingResponse : BaseCryptographyResponse, IPasswordHashingResponse
{
    public BasePasswordHashingResponse(string providedPassword, string hashedPassword)
    {
        ProvidedPassword = providedPassword;
        HashedPassword = hashedPassword;
    }

    public string ProvidedPassword { get; }
    public string HashedPassword { get; }
}