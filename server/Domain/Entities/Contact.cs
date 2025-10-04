using System.Collections.Generic;
using server.Domain.Common;
using server.Shared.Enums;
using server.Shared.ValueObjects;
using server.Domain.Entities.Transactions;

namespace server.Domain.Entities;

public class Contact : BaseEntity
{
  public string Name { get; set; }

  public TelephoneValueObject? Telephone { get; set; }

  public string? ImageUrl { get; set; }

  public string DisplayName { get; set; }

  public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
  public ICollection<Bill> Bills { get; set; } = new List<Bill>();
  public ICollection<BudgetDetail> BudgetDetails { get; set; } = new List<BudgetDetail>();
  public ICollection<GroceryList> GroceryLists { get; set; } = new List<GroceryList>();
}