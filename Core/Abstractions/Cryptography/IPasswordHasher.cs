namespace Core;

public interface IPasswordHasher
{
    string Hash(string password);
    PasswordVerificationResult Verify(string providedPassword, string hashedPassword);
}