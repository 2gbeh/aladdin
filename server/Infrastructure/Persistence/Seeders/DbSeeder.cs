namespace Infrastructure.Persistence.Seed;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        ContactSeeder.Seed(context);
        TransactionCategorySeeder.Seed(context);
        TransactionTagSeeder.Seed(context);
    }
}
