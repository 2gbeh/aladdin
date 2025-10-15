using server.Domain.Entities;

namespace server.Infrastructure.Persistence.Seeders;

public static class TransactionCategorySeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.TransactionCategories.Any())
        {
            context.TransactionCategories.AddRange(
                new TransactionCategory { Name = "Church" },
                new TransactionCategory { Name = "Family" },
                new TransactionCategory { Name = "Groceries" },
                new TransactionCategory { Name = "Utilities" },
                new TransactionCategory { Name = "Healthcare" },
                new TransactionCategory { Name = "Education" },
                new TransactionCategory { Name = "Social" },
                new TransactionCategory { Name = "House" },
                new TransactionCategory { Name = "Car" },
                new TransactionCategory { Name = "Investment" },
                new TransactionCategory { Name = "Loan" },
                new TransactionCategory { Name = "Support" },
                new TransactionCategory { Name = "Emergency" },
                new TransactionCategory { Name = "Frivolous" },
                new TransactionCategory { Name = "Misc" }
            );
            context.SaveChanges();
        }
    }
}