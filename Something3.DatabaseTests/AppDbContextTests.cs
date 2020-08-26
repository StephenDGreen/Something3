using Something3.Core.Model;
using Something3.DatabaseTests.Infrastructure.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Something3.Database.Tests
{
    [TestClass()]
    public class AppDbContextTests
    {
        [TestMethod()]
        public void SavesSomething3ToDatabase()
        {
            var something3 = new Core.Model.Something3() { FullName = "Fred Bloggs" };
            using (var ctx = new DbContextFactory().CreateAppDbContext(nameof(SavesSomething3ToDatabase)))
            {
                ctx.Something3s.Add(something3);
                ctx.SaveChanges();
            };
            using (var ctx = new DbContextFactory().CreateAppDbContext(nameof(SavesSomething3ToDatabase)))
            {
                var savedSomething3 = ctx.Something3s.Single();
                AreEqual(something3.FullName, savedSomething3.FullName);
            };
        }
    }
}