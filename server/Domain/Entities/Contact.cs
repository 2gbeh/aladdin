using System.Collections.Generic;
using server.Domain.Common;
using server.Shared.ValueObjects;

namespace server.Domain.Entities;

public class Contact : BaseEntity
{
  public string Name { get; set; } = string.Empty; // Required in EF config

  public TelephoneValueObject? Telephone { get; set; }

  public string? ImageUrl { get; set; } // Optional in EF config

  public string? DisplayName { get; set; } // Optional in EF config

  public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
  public ICollection<Bill> Bills { get; set; } = new List<Bill>();
  public ICollection<BudgetDetail> BudgetDetails { get; set; } = new List<BudgetDetail>();
  public ICollection<GroceryList> GroceryLists { get; set; } = new List<GroceryList>();
}