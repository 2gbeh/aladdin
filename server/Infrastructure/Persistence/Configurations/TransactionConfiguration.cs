using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities.Transaction;

namespace server.Infrastructure.Persistence.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("transactions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.SenderBeneficiary)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(1024);

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.PaymentDate)
            .IsRequired();

        // Removed old JSON mapping for string-based tags; now tags are a many-to-many with TransactionTag
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

        // Concurrency token from BaseEntity
        builder.Property(x => x.RowVersion)
            .IsConcurrencyToken()
            .IsRowVersion();
    }
}