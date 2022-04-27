namespace Core;

public class PasswordVerificationResult
{
    public bool Verified { get; set; }
    public bool RehashNeeded { get; set; }
}