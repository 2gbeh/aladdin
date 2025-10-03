namespace Infrastructure.Persistence.Seed;

public static class DbSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        TransactionCategorySeeder.Seed(context);
        TransactionTagSeeder.Seed(context);
    }
}
