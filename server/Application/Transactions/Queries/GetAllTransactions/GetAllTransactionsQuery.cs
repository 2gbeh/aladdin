using MediatR;
using server.Application.Common.Queries;
using server.Shared.Dtos;

namespace server.Application.Transactions.Queries;

public sealed record GetAllTransactionsQuery : BasePagedQuery, IRequest<IEnumerable<TransactionDto>>
{
}