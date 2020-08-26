using ClassLibrary1.Application.Services;
using ClassLibrary1.Core;
using ClassLibrary1.Core.Model;
using ClassLibrary1.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void GetThings__ReturnsListOfSomething3WithId()
        {
            var mockInteractor = new Mock<ISomething3Interactor>();
            var mockDisplayInteractor = new Mock<ISomething3DisplayInteractor>();
            int expectedId = 1;
            var something3 = new Something3()
            {
                FullName = "My Pal"
            };

            using (var ctx = new DbContextFactory().CreateAppDbContext(nameof(GetThings__ReturnsListOfSomething3WithId)))
            {
                IClassLibraryPersistence persistence = new ClassLibraryPersistence(ctx);
                persistence.SaveSomething3(something3);
            };

            using (var ctx = new DbContextFactory().CreateAppDbContext(nameof(GetThings__ReturnsListOfSomething3WithId)))
            {
                var controller = new HomeController(mockInteractor.Object, mockDisplayInteractor.Object, ctx);
            
                List<Something3WithId> results = controller.GetThings();
                Assert.AreEqual(something3.FullName, results[0].FullName);
                Assert.AreEqual(expectedId, results[0].Id);
            }
        }
    }
}