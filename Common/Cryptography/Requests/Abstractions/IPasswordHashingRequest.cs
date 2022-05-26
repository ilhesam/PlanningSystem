namespace Core;

public interface IPasswordHashingRequest : IRequest
{
    string Password { get; set; }
}