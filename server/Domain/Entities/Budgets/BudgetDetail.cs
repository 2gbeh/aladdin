using server.Domain.Common;
using server.Shared.ValueObjects;

namespace server.Domain.Entities;

public class BudgetDetail : BaseEntity
{
    public Guid ContactId { get; set; }
    public Contact Contact { get; set; }

    public MoneyValueObject Amount { get; set; }

    public string Description { get; set; }
    
    public DateOnly PaymentDate { get; set; }

    // Optional Receipt link
    public Guid? ReceiptId { get; set; }
    public Receipt? Receipt { get; set; }
}