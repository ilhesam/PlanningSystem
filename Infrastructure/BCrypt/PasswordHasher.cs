using Core;

namespace BCrypt;

public class BCryptPasswordHasher : IPasswordHasher
{
    private readonly int workFactor = 12;

    public string Hash(string password) => Net.BCrypt.HashPassword(password, workFactor);

    public PasswordVerificationResult Verify(string providedPassword, string hashedPassword)
    {
        return new PasswordVerificationResult
        {
            Verified = Net.BCrypt.Verify(providedPassword, hashedPassword),
            RehashNeeded = Net.BCrypt.PasswordNeedsRehash(hashedPassword, workFactor)
        };
    }
}