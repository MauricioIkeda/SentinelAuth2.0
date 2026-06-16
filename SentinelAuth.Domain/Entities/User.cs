using Generic.Domain.Entities;
using Generic.Domain.Shared;
using SentinelAuth.Domain.ValueObjects;

namespace SentinelAuth.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; }

    private User(){}
    
    private User(string name,  Email email, string passwordHash)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
    }

    public static Result<User> Create(string name, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result<User>.Failed("Nome invalido", ErrorType.Validation);
        }
        
        Result<Email> emailValidation = Email.Create(email);

        if (emailValidation.IsFailure)
        {
            return Result<User>.Failed(emailValidation.Message, emailValidation.ErrorType!.Value);
        }
        
        var user = new User(name, emailValidation.Data!, password);
        
        return Result<User>.Success("Usuario criado com sucesso", user);
    }
}