
using server.Domain.ValueObjects;

namespace server.Domain.Entities;

public class BudgetDetail : BaseEntity
{
    public Guid ContactId { get; set; }
    public Contact Contact { get; set; } = null!; // Required navigation property

    public MoneyValueObject Amount { get; set; } = MoneyValueObject.Create(0, "NGN");

    public string Description { get; set; } = string.Empty;
    
    public DateOnly PaymentDate { get; set; }

    // Optional Receipt link
    public Guid? ReceiptId { get; set; }
    public Receipt? Receipt { get; set; }
}