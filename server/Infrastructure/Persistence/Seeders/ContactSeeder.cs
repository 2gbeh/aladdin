using server.Domain.Entities;
using server.Infrastructure.Persistence;

namespace Infrastructure.Persistence.Seed;

public static class ContactSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Contacts.Any())
        {
            context.Contacts.AddRange(
                new Contact { Name = "Tugbeh Roseline Abieyuwa", DisplayName = "Mom" },
                new Contact { Name = "Tugbeh Jackson Aisosa", DisplayName = "Jackson" },
                new Contact { Name = "Sandra Ehiaghe", DisplayName = "The Wife" },
                new Contact { Name = "Shaka Kelly", DisplayName = "Landlord" },
                new Contact { Name = "Ummi Shaka", DisplayName = "Landlady" },
                new Contact { DisplayName = "Mama Elliot" },
                new Contact { DisplayName = "Mama Promise" },
                new Contact { Name = "Philip Sunday", DisplayName = "Duke Bike" },
                new Contact { DisplayName = "Corel Ministry Int'l" },
                new Contact { Name = "Ben Ifeanyi", DisplayName = "Mr Ben" },
                new Contact { Name = "Victor Okonofua", DisplayName = "Omovics" },
                new Contact { Name = "Samuel Lawrence Eyak", DisplayName = "Sam Dryclean" },
                new Contact { Name = "Friday Ifada", DisplayName = "Arthur" },
                new Contact { Name = "Bright Omonigho Okolo", DisplayName = "Zino" }
            );
            context.SaveChanges();
        }
    }
}