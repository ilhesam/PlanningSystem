namespace Core;

public class BasePasswordVerificationRequest : BaseCryptographyRequest, IPasswordVerificationRequest
{
    public BasePasswordVerificationRequest(string providedPassword, string hashedPassword, CancellationToken cancellationToken = default) : base(cancellationToken)
    {
        ProvidedPassword = providedPassword;
        HashedPassword = hashedPassword;
    }

    public string ProvidedPassword { get; set; }
    public string HashedPassword { get; set; }
}