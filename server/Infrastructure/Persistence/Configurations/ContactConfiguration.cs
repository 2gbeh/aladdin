using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities;

namespace server.Infrastructure.Persistence.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("contacts");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(a => a.DisplayName)
            .HasMaxLength(128)
            .IsRequired(false);

        builder.Property(a => a.AvatarUrl)
            .HasMaxLength(512)
            .IsRequired(false);

        // Owned value object mapping for Telephone
        builder.OwnsOne(a => a.Telephone, tb =>
        {
            tb.Property(p => p.E164)
              .HasColumnName("Telephone")
              .HasMaxLength(14) // +234 + 10 digits
              .IsRequired(false);

            // Optional unique index if desired
            tb.HasIndex(p => p.E164).HasDatabaseName("IX_contacts_Telephone");
        });

        // Concurrency token from BaseEntity
        builder.Property(a => a.RowVersion)
            .IsConcurrencyToken()
            .IsRowVersion();
    }
}
