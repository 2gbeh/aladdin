using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Infrastructure.Persistence;
using server.Shared.Dtos;

namespace server.Application.Transactions.Queries;

public sealed class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionDto>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllTransactionsQueryHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TransactionDto>> Handle(GetAllTransactionsQuery req, CancellationToken ct)
    {
        var query = _context.Transactions
            .Include(i => i.Contact)
            .Include(i => i.Category)
            .Include(i => i.Tags)
            .AsQueryable();

        query = ApplySearchFilter(query, req.SearchTerm);

        query = ApplyPagination(query, req.Skip, req.Take);

        var transactions = await query
            .OrderByDescending(t => t.PaymentDate)
            .ToListAsync(ct);

        return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
    }

    private static IQueryable<Transaction> ApplySearchFilter(IQueryable<Transaction> query, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return query;

        return query.Where(w =>
            w.Amount.ToString().Contains(searchTerm) ||
            w.Description.Contains(searchTerm) ||
            w.PaymentDate.ToString().Contains(searchTerm) ||
            (w.Category != null && w.Category.Name.Contains(searchTerm)) ||
            w.Tags.Any(tag => tag.Name.Contains(searchTerm)) ||
            (w.Contact != null && w.Contact.Name.Contains(searchTerm)) ||
            w.CreatedAt.ToString().Contains(searchTerm) ||
            (w.UpdatedAt.HasValue && w.UpdatedAt.Value.ToString().Contains(searchTerm)));
    }

    private static IQueryable<Transaction> ApplyPagination(IQueryable<Transaction> query, int? skip, int? take)
    {
        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }

        return query;
    }
}