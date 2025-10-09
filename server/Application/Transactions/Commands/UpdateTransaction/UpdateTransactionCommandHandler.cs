using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Infrastructure.Persistence;
using server.Shared.Dtos;
using server.Shared.ValueObjects;

namespace server.Application.Transactions.Commands.UpdateTransaction;

public sealed class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, TransactionDto?>
{
    private readonly AppDbContext _context;

    public UpdateTransactionCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TransactionDto?> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await _context.Transactions
            .Include(t => t.Tags)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (transaction == null)
            return null;

        // Update transaction properties
        transaction.Type = request.Type;
        transaction.ContactId = request.ContactId;
        transaction.Amount = MoneyValueObject.Create(request.Amount, request.Currency);
        transaction.Description = request.Description;
        transaction.CategoryId = request.CategoryId;
        transaction.Status = request.Status;
        transaction.PaymentDate = request.PaymentDate;
        transaction.ReceiptId = request.ReceiptId;

        // Update tags
        if (request.TagIds != null)
        {
            transaction.Tags.Clear();
            if (request.TagIds.Any())
            {
                var tags = await _context.TransactionTags
                    .Where(tag => request.TagIds.Contains(tag.Id))
                    .ToListAsync(cancellationToken);
                
                foreach (var tag in tags)
                {
                    transaction.Tags.Add(tag);
                }
            }
        }

        await _context.SaveChangesAsync(cancellationToken);

        // Load the updated transaction with related data
        var updatedTransaction = await _context.Transactions
            .Include(t => t.Contact)
            .Include(t => t.Category)
            .Include(t => t.Tags)
            .FirstAsync(t => t.Id == transaction.Id, cancellationToken);

        return MapToDto(updatedTransaction);
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
