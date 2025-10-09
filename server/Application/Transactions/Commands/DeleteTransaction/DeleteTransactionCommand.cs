using MediatR;

namespace server.Application.Transactions.Commands.DeleteTransaction;

public sealed record DeleteTransactionCommand(Guid Id) : IRequest<bool>;
