using Something3.Application.Services;
using Something3.Core;
using Something3.Core.Model;
using Something3.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Something3.API.Controllers;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Something3.DatabaseTests.Infrastructure.Factories;

namespace Something3.IntegrationTests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod()]
        public void HomeController__GetThings__ReturnsListOfSomething3WithId()
        {
            var mockInteractor = new Mock<ISomething3Interactor>();
            var mockDisplayInteractor = new Mock<ISomething3DisplayInteractor>();
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
                var controller = new HomeController(mockInteractor.Object, mockDisplayInteractor.Object, ctx);

                List<Something3WithId> results = controller.GetThings();
                AreEqual(something3.FullName, results[0].FullName);
                AreEqual(expectedId, results[0].Id);
            }
        }
    }
}
