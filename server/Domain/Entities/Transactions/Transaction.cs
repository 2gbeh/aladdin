using System.Collections.Generic;
using server.Domain.Common;
using server.Shared.Enums;
using server.Domain.Entities;
using server.Shared.ValueObjects;

namespace server.Domain.Entities;

public class Transaction : BaseEntity
{
    public TransactionTypeEnum Type { get; set; } = TransactionTypeEnum.Debit;    

    public Guid? ContactId { get; set; }
    public Contact? Contact { get; set; }

    public MoneyValueObject Amount { get; set; }

    public string? Description { get; set; }

    public Guid? CategoryId { get; set; }
    public TransactionCategory? Category { get; set; }
    
    public ICollection<TransactionTag> Tags { get; set; } = new List<TransactionTag>();
    
    public TransactionStatusEnum Status { get; set; } = TransactionStatusEnum.Fulfilled;

    public DateOnly PaymentDate { get; set; };
}

public enum TransactionTypeEnum
{
    [Display(Name = "debit")]
    Debit,

    [Display(Name = "credit")]
    Credit,
}

public enum TransactionStatusEnum
{
    [Display(Name = "pending")]
    Pending,

    [Display(Name = "fulfilled")]
    Fulfilled,

    [Display(Name = "hidden")]
    Hidden,
}