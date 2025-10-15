using System.ComponentModel.DataAnnotations;

using server.Domain.ValueObjects;
using server.Shared.Utilities;

namespace server.Domain.Entities;

public class Transaction : BaseEntityWithContact
{
    public TransactionTypeEnum Type { get; set; } = TransactionTypeEnum.Debit;
    public MoneyValueObject Amount { get; set; } = MoneyValueObject.Create();    
    public string Description { get; set; }  = "";
    public DateOnly PaymentDate { get; set; } = DateTimeUtil.TodayDateOnly();
    public TransactionStatusEnum Status { get; set; } = TransactionStatusEnum.Fulfilled;  
    // Relationships
    public Guid CategoryId { get; set; }
    public TransactionCategory? Category { get; set; }
    public ICollection<TransactionTag> Tags { get; set; } = [];
    // public Guid? ReceiptId { get; set; }
    // public Receipt? Receipt { get; set; }
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