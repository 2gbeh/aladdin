using server.Domain.Entities;

namespace server.Shared.Dtos;

public class TransactionDto
{
    public TransactionTypeEnum Type { get; set; }
    public string TypeText => Type.ToString();
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public DateTime? PaymentDate { get; set; }
    public TransactionStatusEnum? Status { get; set; }    
    public string StatusText => Status?.ToString() ?? "";
    public LookupEntityDto? Category { get; set; }    
    public IEnumerable<LookupEntityDto>? Tags { get; set; }    
}

public class TransactionEntityDto : BaseEntityDto
{
}

public class TransactionSummaryDto : TransactionDto
{
    Guid Id { get; set; }
    ContactSummaryDto? Contact { get; set; }

}
