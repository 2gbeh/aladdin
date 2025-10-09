using MediatR;
using server.Shared.Dtos;

namespace server.Application.Transactions.Queries.GetAllTransactions;

public sealed record GetAllTransactionsQuery : IRequest<IEnumerable<TransactionDto>>
{
    public int? Skip { get; init; }
    public int? Take { get; init; }
    public string? SearchTerm { get; init; }
    public Guid? ContactId { get; init; }
    public Guid? CategoryId { get; init; }
}