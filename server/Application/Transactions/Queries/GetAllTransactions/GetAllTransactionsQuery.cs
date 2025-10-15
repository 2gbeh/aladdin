using MediatR;
using server.Application.Common.Queries;
using server.Application.Common.Dtos;

namespace server.Application.Transactions.Queries.GetAllTransactions;

public sealed class GetAllTransactionsDto : List<TransactionEntityDto>
{
}

public sealed record GetAllTransactionsQuery : BasePagedQuery, IRequest<GetAllTransactionsDto>
{
}

public interface IGetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, GetAllTransactionsDto> { }
