using Domain;

namespace Service;

public interface IAuthenticationProvider
{
    AuthenticationCredential IssueCredential(User user);
}