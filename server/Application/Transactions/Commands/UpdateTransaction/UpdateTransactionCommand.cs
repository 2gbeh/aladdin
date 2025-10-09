using MediatR;
using server.Domain.Entities;
using server.Shared.Dtos;

namespace server.Application.Transactions.Commands.UpdateTransaction;

public sealed record UpdateTransactionCommand(
    Guid Id,
    TransactionTypeEnum Type,
    Guid? ContactId,
    decimal Amount,
    string Currency,
    string? Description,
    Guid? CategoryId,
    IEnumerable<Guid>? TagIds,
    TransactionStatusEnum Status,
    DateOnly PaymentDate,
    Guid? ReceiptId
) : IRequest<TransactionDto?>;
