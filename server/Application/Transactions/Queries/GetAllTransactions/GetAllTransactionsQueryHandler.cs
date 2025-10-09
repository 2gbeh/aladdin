using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Infrastructure.Persistence;
using server.Shared.Dtos;

namespace server.Application.Transactions.Queries.GetAllTransactions;

public sealed class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionDto>>
{
    private readonly AppDbContext _context;

    public GetAllTransactionsQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TransactionDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Transactions
            .Include(t => t.Contact)
            .Include(t => t.Category)
            .Include(t => t.Tags)
            .AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            query = query.Where(t => 
                (t.Description != null && t.Description.Contains(request.SearchTerm)) ||
                (t.Contact != null && t.Contact.Name.Contains(request.SearchTerm)) ||
                (t.Category != null && t.Category.Name.Contains(request.SearchTerm)));
        }

        if (request.ContactId.HasValue)
        {
            query = query.Where(t => t.ContactId == request.ContactId.Value);
        }

        if (request.CategoryId.HasValue)
        {
            query = query.Where(t => t.CategoryId == request.CategoryId.Value);
        }

        // Apply pagination
        if (request.Skip.HasValue)
        {
            query = query.Skip(request.Skip.Value);
        }

        if (request.Take.HasValue)
        {
            query = query.Take(request.Take.Value);
        }

        var transactions = await query
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync(cancellationToken);

        return transactions.Select(MapToDto);
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