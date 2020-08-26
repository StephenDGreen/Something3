using ClassLibrary1.Database;
using Microsoft.EntityFrameworkCore;

namespace Something3.IntegrationTests
{
    public class DbContextFactory
    {
        public AppDbContext CreateAppDbContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName).Options;

            return new AppDbContext(options);
        }
    }
}