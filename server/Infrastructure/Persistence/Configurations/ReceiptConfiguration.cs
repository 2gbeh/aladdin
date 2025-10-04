using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities;

namespace server.Infrastructure.Persistence.Configurations;

public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
{
    public void Configure(EntityTypeBuilder<Receipt> builder)
    {
        builder.ToTable("receipts");

        builder.HasKey(x => x.Id);

        // Own File value object and store as JSON
        builder.OwnsOne(r => r.File, f =>
        {
            f.ToJson();
            f.Property(p => p.Name).HasMaxLength(255);
            f.Property(p => p.Url).HasMaxLength(1024);
            f.Property(p => p.Type).HasMaxLength(128);
        });

        // Relationships are left as-is; using default FK conventions on join entities elsewhere
    }
}
