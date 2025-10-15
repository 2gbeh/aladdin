using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities;

namespace server.Infrastructure.Persistence.Configurations;

public class TransactionConfiguration : BaseConfiguration<Transaction>
{
    public override void Configure(EntityTypeBuilder<Transaction> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Type)
            .IsRequired();

        MoneyProperty(builder, x => x.Amount);

        builder.Property(x => x.Description)
            .IsRequired();

        builder.Property(x => x.PaymentDate)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasMany(x => x.Tags)
            .WithMany()
            .UsingEntity(x => x.ToTable("transaction_tags_pivot"));

        HasContact(builder, x => x.Transactions);

        // Indexes
        builder.HasIndex(x => x.PaymentDate);
    }
}