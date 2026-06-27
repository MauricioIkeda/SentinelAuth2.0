namespace SentinelAuth.Application.Abstractions.Security;

public interface IPasswordHasher
{
    string Hash(string password);
    bool VerifyPassword(string providedPassword, string hashedPassword);
}