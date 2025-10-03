namespace Infrastructure.Persistence.Seed;

public static class TransactionTagSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        if (!context.TransactionTags.Any())
        {
            context.TransactionTags.AddRange(
                new TransactionTag { Name = "Airtime" }
                new TransactionTag { Name = "Data" },
                new TransactionTag { Name = "Electricity" },
                new TransactionTag { Name = "Fuel" },
                new TransactionTag { Name = "Gas" },
                new TransactionTag { Name = "Generator" },
                new TransactionTag { Name = "Water" },
            );
            context.SaveChanges();
        }
    }
}