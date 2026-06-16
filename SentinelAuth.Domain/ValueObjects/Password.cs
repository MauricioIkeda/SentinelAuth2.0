using Generic.Domain.Shared;

namespace SentinelAuth.Domain.ValueObjects;

public sealed class Password
{
    public string Value { get; set; }

    private const int MinLength = 8;
    private const int MaxLength = 128;

    private Password(string value)
    {
        Value = value;
    }

    public static Result<Password> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result<Password>.Failed("Senha invalida", ErrorType.Validation);
        }

        if (value.Length < MinLength)
        {
            return Result<Password>.Failed("Senha precisa conter mais que 7 caracteres", ErrorType.Validation);
        }
        
        if (value.Length > MaxLength)
        {
            return Result<Password>.Failed("Senha deve conter menos de 128 caracteres", ErrorType.Validation);
        }

        var password = new Password(value);

        return Result<Password>.Success("Senha criada com sucesso", password);
    }
}