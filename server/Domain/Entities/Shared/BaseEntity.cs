using System.ComponentModel.DataAnnotations;

namespace server.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    [Timestamp]
    public byte[]? RowVersion { get; set; }
}

public abstract class BaseEntityWithContact : BaseEntity
{
    public Guid ContactId { get; set; }
    public Contact? Contact { get; set; }
}