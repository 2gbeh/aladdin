using System.ComponentModel.DataAnnotations;

namespace server.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    [Timestamp]
    public byte[]? RowVersion { get; set; }
}