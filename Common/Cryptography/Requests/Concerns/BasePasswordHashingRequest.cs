namespace Core;

public class BasePasswordHashingRequest : BaseCryptographyRequest, IPasswordHashingRequest
{
    public BasePasswordHashingRequest(string password, CancellationToken cancellationToken = default) : base(cancellationToken)
    {
        Password = password;
    }

    public string Password { get; set; }
}