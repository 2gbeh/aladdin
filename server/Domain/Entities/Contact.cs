
using server.Domain.ValueObjects;

namespace server.Domain.Entities;

public class Contact : BaseEntity
{
  public string? ImageUrl { get; set; }
  public string Name { get; set; } = "";
  public string? BusinessName { get; set; }
  public TelephoneValueObject? Telephone { get; set; }
  public ICollection<Transaction> Transactions { get; set; } = [];
  // public ICollection<Bill> Bills { get; set; } = new List<Bill>();
  // public ICollection<BudgetDetail> BudgetDetails { get; set; } = new List<BudgetDetail>();
  // public ICollection<GroceryList> GroceryLists { get; set; } = new List<GroceryList>();
}