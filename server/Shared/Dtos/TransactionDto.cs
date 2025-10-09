using server.Domain.Entities;

namespace server.Shared.Dtos;

public sealed record TransactionDto(
    Guid Id,

    TransactionTypeEnum Type,
    
    Guid? ContactId,
    string? ContactName,
    string? ContactDisplayName,
    
    decimal Amount,
    string Currency,
    
    string? Description,

    string? TransactionCategoryName,

    IEnumerable<LookupDto> Tags,

    TransactionStatusEnum Status,

    DateTime PaymentDate,

    DateTime CreatedAt,

    DateTime? UpdatedAt
);