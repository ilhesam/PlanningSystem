using Core;

namespace BCrypt;

public class BCryptPasswordHasher : IPasswordHasher
{
    private readonly int workFactor = 12;

    public IPasswordHashingResponse Hash(IPasswordHashingRequest request)
    {
        var hash = Net.BCrypt.HashPassword(request.Password, workFactor);
        return new BasePasswordHashingResponse(request.Password, hash);
    }

    public IPasswordVerificationResponse Verify(IPasswordVerificationRequest request)
    {
        return new BasePasswordVerificationResponse
        {
            Verified = Net.BCrypt.Verify(request.ProvidedPassword, request.HashedPassword),
            RehashNeeded = Net.BCrypt.PasswordNeedsRehash(request.HashedPassword, workFactor)
        };
    }
}