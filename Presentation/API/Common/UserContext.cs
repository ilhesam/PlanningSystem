namespace API;

public class UserContext : IUserContext
{
    public UserContext(IHttpContextAccessor accessor)
    {
        UserName = accessor.HttpContext?.User.Identity?.Name;
        IpAddress = accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
    }

    public string UserName { get; set; }
    public string IpAddress { get; set; }
}