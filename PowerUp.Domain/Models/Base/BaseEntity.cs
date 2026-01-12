namespace PowerUp.Domain.Models.Base;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}