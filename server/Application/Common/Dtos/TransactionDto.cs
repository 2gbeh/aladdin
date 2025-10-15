using server.Domain.Entities;

namespace server.Application.Common.Dtos;

public class TransactionDto : EntityDto
{
    public TransactionTypeEnum Type { get; init; }
    public decimal Amount { get; init; }
    public string Description { get; init; } = "";
    public DateTime PaymentDate { get; init; }
    public TransactionStatusEnum Status { get; init; }
    public LookupDto? Category { get; init; }
    public IEnumerable<LookupDto>? Tags { get; init; }
}

public class TransactionEntityDto : TransactionDto
{
    public ContactDto? Contact { get; init; }
}

public class TransactionLookupDto : IdentifierDto
{
    public TransactionTypeEnum Type { get; init; }
    public decimal Amount { get; init; }
}