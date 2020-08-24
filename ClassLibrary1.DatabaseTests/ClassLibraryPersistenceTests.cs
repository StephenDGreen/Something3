using ClassLibrary1.Core;
using ClassLibrary1.Core.Model;
using ClassLibrary1.DatabaseTests.Infrastructure.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ClassLibrary1.Database.Tests
{
    [TestClass()]
    public class ClassLibraryPersistenceTests
    {
        [TestMethod()]
        public void PersistsSomething3()
        {
            var something3 = new Something3()
            {
                FullName = "My Pal"
            };

            using (var ctx = new DbContextFactory().CreateAppDbContext(nameof(PersistsSomething3)))
            {
                IClassLibraryPersistence persistence = new ClassLibraryPersistence(ctx);
                persistence.SaveSomething3(something3);
            };

            using (var ctx = new DbContextFactory().CreateAppDbContext(nameof(PersistsSomething3)))
            {
                var savedSomething3 = ctx.Something3s.Single();
                AreEqual(something3.FullName, savedSomething3.FullName);
            };
        }
        [TestMethod()]
        public void GetsSomething3List()
        {
            var something3 = new Something3()
            {
                FullName = "My Pal"
            };

            using (var ctx = new DbContextFactory().CreateAppDbContext(nameof(GetsSomething3List)))
            {
                IClassLibraryPersistence persistence = new ClassLibraryPersistence(ctx);
                persistence.SaveSomething3(something3);
            };

            using (var ctx = new DbContextFactory().CreateAppDbContext(nameof(GetsSomething3List)))
            {
                IClassLibraryPersistence persistence = new ClassLibraryPersistence(ctx);
                var savedSomething3 = persistence.GetSomething3List();
                AreEqual(something3.FullName, savedSomething3.Single().FullName);
            }; 

            
        }
    }
}