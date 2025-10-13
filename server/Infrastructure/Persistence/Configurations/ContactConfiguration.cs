using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities;
using server.Infrastructure.Common;

namespace server.Infrastructure.Persistence.Configurations;

public class ContactConfiguration : BaseConfiguration<Contact>
{
    public override void Configure(EntityTypeBuilder<Contact> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.ImageUrl);

        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.BusinessName);
        
        TelephoneProperty(builder, x => x.Telephone);
    }
}