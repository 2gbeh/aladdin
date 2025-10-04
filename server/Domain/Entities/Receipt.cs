using System.Collections.Generic;
using server.Domain.Common;
using server.Shared.Enums;
using server.Shared.ValueObjects;
using server.Domain.Entities.Transactions;

namespace server.Domain.Entities;

public class Receipt : BaseEntity
{
  public FileValueObject? File { get; set; }
}