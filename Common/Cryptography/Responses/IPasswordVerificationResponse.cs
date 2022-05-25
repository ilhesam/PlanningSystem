namespace Core;

public interface IPasswordVerificationResponse : ICryptographyResponse
{
    bool Verified { get; }
    bool RehashNeeded { get; }
    Exception Exception { get; }
}