

namespace server.Domain.Entities;

public class GroceryList : BaseEntity
{
    // Required descriptive name of the bill
    public string Name { get; set; } = string.Empty;

    // Link to Contact (required at domain level; DB FK can be required as well)
    public Guid ContactId { get; set; }
    public Contact? Contact { get; set; }

    public string? Description { get; set; }

    public DateOnly? Date { get; set; }

    // Line items making up the bill
    public ICollection<GroceryListItem> Items { get; set; } = new List<GroceryListItem>();
}