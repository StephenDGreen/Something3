using Something3.Application.Services;
using Something3.Core;
using Something3.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Something3.DatabaseTests.Infrastructure.Factories;
using Something3.Database;
using Something3.Application.ViewModel;

namespace Something3.Application.Services.Tests
{
    [TestClass()]
    public class Something3DisplayInteractorTests
    {
        [TestMethod()]
        public void DisplaySomething3__DisplaysSomething3()
        {
            //arrange
            var something3 = new List<Core.Model.Something3>();
            something3.Add(new Something3.Core.Model.Something3 { FullName = "Fred Bloggs" });
            var mockPersistence = new Mock<IClassLibraryPersistence>();
            mockPersistence.Setup(x => x.GetSomething3List()).Returns(something3);
            Something3DisplayInteractor interactor = new Something3DisplayInteractor(mockPersistence.Object);
            //act
            List<Core.Model.Something3> something = interactor.GetSomething3List();
            AreEqual(something3.Count, something.Count);
            AreEqual(something3[something3.Count - 1].FullName, something[something.Count - 1].FullName);
        }

        [TestMethod()]
        public void HomeController__GetThings__ReturnsListOfSomething3WithId()
        {
            var mockInteractor = new Mock<ISomething3Interactor>();
            int expectedId = 1;
            var something3 = new Something3.Core.Model.Something3()
            {
                FullName = "My Pal"
            };

            using (var ctx = new DbContextFactory().CreateAppDbContext(nameof(HomeController__GetThings__ReturnsListOfSomething3WithId)))
            {
                IClassLibraryPersistence persistence = new ClassLibraryPersistence(ctx);
                persistence.SaveSomething3(something3);
            };

            using (var ctx = new DbContextFactory().CreateAppDbContext(nameof(HomeController__GetThings__ReturnsListOfSomething3WithId)))
            {
                IClassLibraryPersistence persistence = new ClassLibraryPersistence(ctx);
                var interactor = new Something3DisplayInteractor(persistence, ctx);

                List<Something3WithId> results = interactor.GetThings();
                AreEqual(something3.FullName, results[0].FullName);
                AreEqual(expectedId, results[0].Id);
            }
        }
    }
}