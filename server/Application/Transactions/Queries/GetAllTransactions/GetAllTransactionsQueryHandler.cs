using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Infrastructure.Persistence;

namespace server.Application.Transactions.Queries.GetAllTransactions;

public sealed class GetAllTransactionsQueryHandler : IGetAllTransactionsQueryHandler
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllTransactionsQueryHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetAllTransactionsDto> Handle(GetAllTransactionsQuery req, CancellationToken ct)
    {
        var query = _context.Transactions
            .Include(i => i.Contact)
            .Include(i => i.Category)
            .Include(i => i.Tags)
            .AsQueryable();

        query = ApplySearchFilter(query, req.SearchTerm);

        query = ApplyPagination(query, req.Skip, req.Take);

        var result = await query
            .OrderByDescending(t => t.PaymentDate)
            .ToListAsync(ct);

        return _mapper.Map<GetAllTransactionsDto>(result);
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