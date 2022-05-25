namespace Core;

public interface IPasswordHasher : IHandler
{
    IPasswordHashingResponse Hash(IPasswordHashingRequest request);
    IPasswordVerificationResponse Verify(IPasswordVerificationRequest request);
}