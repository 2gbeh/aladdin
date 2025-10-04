using server.Domain.Common;
using server.Shared.ValueObjects;

namespace server.Domain.Entities;

public class Receipt : BaseEntity
{
  public FileValueObject? File { get; set; }
}