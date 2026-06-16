namespace Generic.Domain.Entities;

public abstract class BaseEntity
{
    public long Id { get; protected set; }
    public DateTimeOffset CreatedAt { get; protected set; }
    public DateTimeOffset UpdatedAt { get; protected set; }

    public BaseEntity()
    {
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}