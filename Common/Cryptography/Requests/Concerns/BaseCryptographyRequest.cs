namespace Core;

public class BaseCryptographyRequest : BaseRequest, ICryptographyRequest
{
    public BaseCryptographyRequest(CancellationToken cancellationToken = default) : base(cancellationToken)
    {
    }
}