using MediatR;
using server.Shared.Dtos;

namespace server.Application.Transactions.Queries.GetTransactionById;

public sealed record GetTransactionByIdQuery(Guid Id) : IRequest<TransactionDto?>;
