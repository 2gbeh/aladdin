using server.Domain.Common;
using server.Shared.ValueObjects;

namespace server.Domain.Entities;

public class GroceryListItem : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    // Parent bill (required)
    public Guid GroceryListId { get; set; }
    public GroceryList? GroceryList { get; set; }

    // Optional amount per item (use MoneyValueObject for currency safety)
    public MoneyValueObject? EstimatedPrice { get; set; }

    public MoneyValueObject? ActualPrice { get; set; }

    // Quantity with sensible default
    public int Qty { get; set; } = 1;
}