namespace Core;

public interface IAuthenticationProvider
{
    AuthenticationCredential IssueCredential(User user);
}