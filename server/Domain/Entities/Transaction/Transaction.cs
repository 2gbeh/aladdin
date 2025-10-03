using System.Collections.Generic;
using server.Domain.Common;
using server.Shared.Enums;

namespace server.Domain.Entities.Transaction;

public class Transaction : BaseEntity
{
    public TransactionTypeEnum Type { get; set; } = TransactionTypeEnum.Debit;    

    public string SenderBeneficiary { get; set; }

    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public Guid? TransactionCategoryId { get; set; }
    public TransactionCategory? Category { get; set; }
    
    public ICollection<TransactionTag> Tags { get; set; } = new List<TransactionTag>();
    
    public TransactionStatusEnum Status { get; set; } = TransactionStatusEnum.Default;

    public DateTime PaymentDate { get; set; };
}