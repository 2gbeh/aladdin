
using server.Domain.ValueObjects;

namespace server.Domain.Entities;

public class Receipt : BaseEntity
{
  public FileValueObject? File { get; set; }
}