using MongoRepo.Context;

namespace Catalog.API.Context
{
    public class CatalogDbContext : ApplicationDbContext
    {
        static IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();
        static string connectionString = config.GetConnectionString("Catalog.API");
        static string databaseName = config.GetValue<string>("DatabaseName");

        public CatalogDbContext() : base(connectionString, databaseName)
        {
        }
    }
}
