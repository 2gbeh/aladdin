using server.Domain.Entities;

namespace server.Infrastructure.Persistence.Seeders;

public static class ContactSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Contacts.Any())
        {
            context.Contacts.AddRange(
                new Contact { BusinessName = "Tugbeh Roseline Abieyuwa", Name = "Mom" },
                new Contact { BusinessName = "Tugbeh Jackson Aisosa", Name = "Jackson" },
                new Contact { BusinessName = "Sandra Ehiaghe", Name = "The Wife" },
                new Contact { BusinessName = "Shaka Kelly", Name = "Landlord" },
                new Contact { BusinessName = "Ummi Shaka", Name = "Landlady" },
                new Contact { BusinessName = "Austine Aimienota Omoruyi", Name = "Gen. Austine" },
                new Contact { BusinessName = "Ndidi Loveth Onyemuelosi", Name = "Mama Elliot" },
                new Contact { BusinessName = "Mama Promise 2 Store", Name = "Mama Promise" },
                new Contact { BusinessName = "Philip Sunday", Name = "Duke Bike" },
                new Contact { BusinessName = "Corel Ministry Int'l Inc", Name = "Jubilee Chapel" },
                new Contact { BusinessName = "Ben Ifeanyi", Name = "Mr Ben" },
                new Contact { BusinessName = "Victor Okonofua", Name = "Omovics" },
                new Contact { BusinessName = "Samuel Lawrence Eyak", Name = "Sam Drycleaner" },
                new Contact { BusinessName = "Friday Ifada", Name = "Arthur Barber" },
                new Contact { BusinessName = "Bright Omonigho Okolo", Name = "Zino Barber" }
            );
            context.SaveChanges();
        }
    }
}