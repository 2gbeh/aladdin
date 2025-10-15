namespace server.Domain.Entities;

public abstract class LookupEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
}
