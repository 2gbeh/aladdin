using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using server.Domain.Entities;
using server.Domain.ValueObjects;
using System.Linq.Expressions;

namespace server.Infrastructure.Persistence.Configurations;

public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.CreatedAt);
        builder.HasIndex(x => x.UpdatedAt);
        builder.HasIndex(x => x.DeletedAt);

        builder.Property(x => x.RowVersion)
            .IsConcurrencyToken()
            .IsRowVersion();
    }

    protected void MoneyProperty(
        EntityTypeBuilder<T> builder,
        Expression<Func<T, MoneyValueObject?>> propertyExpression
    )
    {
        builder.OwnsOne(propertyExpression, x =>
        {
            x.Property(x => x.Value)
              .HasColumnName("Value")
              .HasPrecision(18, 2)
              .IsRequired();

            x.Property(x => x.Currency)
              .HasColumnName("Currency")
              .HasMaxLength(3)
              .IsRequired();

            x.HasIndex(x => x.Value);
        });
    }

    protected void TelephoneProperty(
        EntityTypeBuilder<T> builder,
        Expression<Func<T, TelephoneValueObject?>> propertyExpression
    )
    {
        builder.OwnsOne(propertyExpression, x =>
        {
            x.Property(x => x.Number)
              .HasColumnName("Number")
              .HasMaxLength(15);

            x.Property(x => x.CountryCode)
              .HasColumnName("CountryCode")
              .HasMaxLength(5);

        });
    }

    protected void HasContact<TEntity>(EntityTypeBuilder<TEntity> builder, Expression<Func<Contact, IEnumerable<TEntity>?>>? inverseNavigation = null) where TEntity : BaseEntityWithContact
    {
        builder.HasOne(x => x.Contact)
            .WithMany(inverseNavigation)
            .HasForeignKey(x => x.ContactId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(x => x.ContactId);
    }
}
