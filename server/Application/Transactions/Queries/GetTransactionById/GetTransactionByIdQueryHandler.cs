using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Infrastructure.Persistence;
using server.Shared.Dtos;

namespace server.Application.Transactions.Queries.GetTransactionById;

public sealed class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, TransactionDto?>
{
    private readonly AppDbContext _context;

    public GetTransactionByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TransactionDto?> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var transaction = await _context.Transactions
            .Include(t => t.Contact)
            .Include(t => t.Category)
            .Include(t => t.Tags)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (transaction == null)
            return null;

        return MapToDto(transaction);
    }

    private static TransactionDto MapToDto(Transaction transaction)
    {
        return new TransactionDto(
            transaction.Id,
            transaction.Type,
            transaction.ContactId,
            transaction.Contact?.Name,
            transaction.Contact?.DisplayName,
            transaction.Amount.Amount,
            transaction.Amount.Currency,
            transaction.Description,
            transaction.Category?.Name,
            transaction.Tags.Select(tag => new LookupDto(tag.Id, tag.Name)),
            transaction.Status,
            transaction.PaymentDate.ToDateTime(TimeOnly.MinValue),
            transaction.CreatedAt,
            transaction.UpdatedAt
        );
    }
}
