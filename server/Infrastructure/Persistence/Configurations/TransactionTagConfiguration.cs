using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities;

namespace server.Infrastructure.Persistence.Configurations;

public class TransactionTagConfiguration : IEntityTypeConfiguration<TransactionTag>
{
    public void Configure(EntityTypeBuilder<TransactionTag> builder)
    {
        builder.ToTable("transaction_tags");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}
