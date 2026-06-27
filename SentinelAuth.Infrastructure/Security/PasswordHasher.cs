using Microsoft.AspNetCore.Identity;
using SentinelAuth.Application.Abstractions.Security;

namespace SentinelAuth.Infrastructure.Security;

public class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<object> _passwordhasher = new();
    
    public string Hash(string password)
    {
        return _passwordhasher.HashPassword(user: null!, password);
    }

    public bool VerifyPassword(string providedPassword, string hashedPassword)
    {
        var result = _passwordhasher.VerifyHashedPassword(user: null!, hashedPassword, providedPassword);
        
        return result is PasswordVerificationResult.Success or PasswordVerificationResult.SuccessRehashNeeded;
    }
}