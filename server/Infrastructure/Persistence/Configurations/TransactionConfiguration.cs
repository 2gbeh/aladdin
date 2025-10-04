using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities.Transaction;
using server.Domain.Entities;

namespace server.Infrastructure.Persistence.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("transactions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Type)
            .IsRequired();

        // Contact (optional)
        builder.HasOne(t => t.Contact)
            .WithMany(c => c.Transactions)
            .HasForeignKey(t => t.ContactId)
            .OnDelete(DeleteBehavior.SetNull);

        // Index for common lookups by contact
        builder.HasIndex(t => t.ContactId);

        // Amount as owned value object (MoneyValueObject)
        builder.OwnsOne(t => t.Amount, mv =>
        {
            mv.Property(p => p.Amount)
              .HasColumnName("Amount")
              .HasPrecision(18, 2)
              .IsRequired();

            mv.Property(p => p.Currency)
              .HasColumnName("Currency")
              .HasMaxLength(3)
              .IsRequired();
        });

        builder.Property(x => x.Description)
            .HasMaxLength(1024);

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.PaymentDate)
            .IsRequired();

        // Many-to-many between Transaction and TransactionTag with explicit join table name
        builder
            .HasMany(t => t.Tags)
            .WithMany()
            .UsingEntity(j => j.ToTable("transaction_tags_join"));

        // Relationship to Category (optional)
        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.TransactionCategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        // Indexes for common queries
        builder.HasIndex(x => x.PaymentDate);
        builder.HasIndex(x => x.Status);
        builder.HasIndex(x => x.TransactionCategoryId);

        // Optional relationship to Receipt
        builder.HasOne(x => x.Receipt)
            .WithMany()
            .HasForeignKey(x => x.ReceiptId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(x => x.ReceiptId);

        // Concurrency token from BaseEntity
        builder.Property(x => x.RowVersion)
            .IsConcurrencyToken()
            .IsRowVersion();
    }
}