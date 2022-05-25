namespace Core;

public interface IPasswordVerificationRequest : IRequest
{
    string ProvidedPassword { get; set; }
    string HashedPassword { get; set; }
}