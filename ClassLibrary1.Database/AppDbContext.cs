using ClassLibrary1.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Something3> Something3s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Something3>().Property<long>("Id");
        }
    }
}
