using System.Collections.Generic;
using server.Domain.Common;
using server.Shared.ValueObjects;

namespace server.Domain.Entities;

public class Bill : BaseEntity
{
    // Required descriptive name of the bill
    public string Name { get; set; } = string.Empty;

    // Link to Contact (required at domain level; DB FK can be required as well)
    public Guid ContactId { get; set; }
    public Contact? Contact { get; set; }

    // Optional total amount if you choose to persist aggregate totals
    // Otherwise, this can be null and computed from Items on the fly
    public MoneyValueObject? Amount { get; set; }

    public string? Description { get; set; }

    public BillStatusEnum Status { get; set; } = BillStatusEnum.Unpaid;

    public DateOnly? PaymentDate { get; set; }

    // Line items making up the bill
    public ICollection<BillDetail> Details { get; set; } = new List<BillDetail>();
}

public enum BillStatusEnum
{
    Unpaid,
    Paid,
}