using Generic.Domain.Shared;

namespace SentinelAuth.Domain.ValueObjects;

public sealed class Email
{
    public string Value { get; set; }

    private Email(string value)
    {
        Value = value;
    }

    public static Result<Email> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result<Email>.Failed("Email invalido", ErrorType.Validation);
        }

        var normalizedEmail = value.Trim().ToLowerInvariant();
        
        if (!normalizedEmail.Contains('@'))
        {
            return Result<Email>.Failed("Email invalido", ErrorType.Validation);
        }

        var email = new Email(value);

        return Result<Email>.Success("Email criado com sucesso", email);
    }
}