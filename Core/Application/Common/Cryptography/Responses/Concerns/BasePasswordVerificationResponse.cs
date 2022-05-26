namespace Core;

public class BasePasswordVerificationResponse : BaseCryptographyResponse, IPasswordVerificationResponse
{
    public bool Verified { get; set; }
    public bool RehashNeeded { get; set; }
}