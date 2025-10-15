namespace server.Infrastructure.Persistence.Seeders;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        ContactSeeder.Seed(context);
        TransactionCategorySeeder.Seed(context);
        TransactionTagSeeder.Seed(context);
    }
}
