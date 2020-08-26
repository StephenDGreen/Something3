using Something3.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Something3.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Something3.Core.Model.Something3> Something3s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Something3.Core.Model.Something3>().Property<long>("Id");
        }
    }
}
