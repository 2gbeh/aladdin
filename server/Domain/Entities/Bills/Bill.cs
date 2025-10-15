using server.Domain.Entities.Shared;
using server.Domain.ValueObjects;

namespace server.Domain.Entities;

public class Bill : BaseEntity
{
    public Guid ContactId { get; set; }
    public Contact? Contact { get; set; }

    // Optional total amount if you choose to persist aggregate totals
    // Otherwise, this can be null and computed from Items on the fly
    public MoneyValueObject? Amount { get; set; }

    public string? Description { get; set; }

    public BillStatusEnum Status { get; set; } = BillStatusEnum.Unpaid;

    public DateOnly? PaymentDate { get; set; }

    // Optional Receipt link
    public Guid? ReceiptId { get; set; }
    public Receipt? Receipt { get; set; }

    // Line items making up the bill
    public ICollection<BillDetail> Details { get; set; } = new List<BillDetail>();
}

public enum BillStatusEnum
{
    Unpaid,
    Paid,
}