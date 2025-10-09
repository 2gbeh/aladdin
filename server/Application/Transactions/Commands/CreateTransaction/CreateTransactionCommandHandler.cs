using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Infrastructure.Persistence;
using server.Shared.Dtos;
using server.Shared.ValueObjects;

namespace server.Application.Transactions.Commands.CreateTransaction;

public sealed class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, TransactionDto>
{
    private readonly AppDbContext _context;

    public CreateTransactionCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TransactionDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Type = request.Type,
            ContactId = request.ContactId,
            Amount = MoneyValueObject.Create(request.Amount, request.Currency),
            Description = request.Description,
            CategoryId = request.CategoryId,
            Status = request.Status,
            PaymentDate = request.PaymentDate,
            ReceiptId = request.ReceiptId,
            CreatedAt = DateTime.UtcNow
        };

        _context.Transactions.Add(transaction);

        // Handle tags if provided
        if (request.TagIds != null && request.TagIds.Any())
        {
            var tags = await _context.TransactionTags
                .Where(tag => request.TagIds.Contains(tag.Id))
                .ToListAsync(cancellationToken);
            
            transaction.Tags = tags;
        }

        await _context.SaveChangesAsync(cancellationToken);

        // Load the created transaction with related data
        var createdTransaction = await _context.Transactions
            .Include(t => t.Contact)
            .Include(t => t.Category)
            .Include(t => t.Tags)
            .FirstAsync(t => t.Id == transaction.Id, cancellationToken);

        return MapToDto(createdTransaction);
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