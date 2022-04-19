using System.Net;

namespace API;

public class UserContext : IUserContext
{
    public UserContext(IHttpContextAccessor accessor)
    {
        UserName = accessor.HttpContext?.User.Identity?.Name;
        IpAddress = accessor.HttpContext?.Connection?.RemoteIpAddress;
    }

    public string UserName { get; set; }
    public IPAddress IpAddress { get; set; }
}