using System.Collections.Generic;
using server.Domain.Common;
using server.Shared.ValueObjects;

namespace server.Domain.Entities;

public class Budget : BaseEntity
{
    // Required descriptive name of the bill
    public string Name { get; set; } = string.Empty;

    // Optional total amount if you choose to persist aggregate totals
    // Otherwise, this can be null and computed from Items on the fly
    public MoneyValueObject? Amount { get; set; }

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    // Line items making up the bill
    public ICollection<BudgetDetail> Details { get; set; } = new List<BudgetDetail>();
}