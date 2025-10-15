
using server.Domain.ValueObjects;

namespace server.Domain.Entities;

public class BillDetail : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    // Parent bill (required)
    public Guid BillId { get; set; }
    public Bill? Bill { get; set; }

    // Optional amount per item (use MoneyValueObject for currency safety)
    public MoneyValueObject? Amount { get; set; }

    // Quantity with sensible default
    public int Qty { get; set; } = 1;

    // When the purchase occurred
    public DateOnly DatePurchased { get; set; }
}