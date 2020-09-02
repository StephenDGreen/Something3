using Moq;
using Something3.Core;
using Something3.Core.ViewModel;
using Something3.Database;
using Something3.Database.Services;
using Something3.DatabaseTests.Infrastructure.Factories;
using System.Collections.Generic;
using Xunit;
using static Xunit.Assert;

namespace Something3.Application.Services.Tests
{
    public class Something3InteractorTests
    {
        [Fact]
        public void CreateSomething3__UsesSomething3FactoryToCreateSomething3()
        {
            //arrange
            var mockSomething3Factory = new Mock<ISomething3Factory>();
            var mockPersistence = new Mock<IClassLibraryPersistence>();
            Something3Interactor something3Interactor = new Something3Interactor(mockSomething3Factory.Object, mockPersistence.Object);
            //act
            something3Interactor.CreateSomething3();
            //assert
            mockSomething3Factory.Verify(x => x.Create());
        }
        [Fact]
        public void CreateSomething3__PersistsSomething3()
        {
            //arrange
            var mockSomething3Factory = new Mock<ISomething3Factory>();
            var something3 = new Core.Model.Something3();
            mockSomething3Factory.Setup(x => x.Create()).Returns(something3);
            var mockPersistence = new Mock<IClassLibraryPersistence>();
            Something3Interactor something3Interactor = new Something3Interactor(mockSomething3Factory.Object, mockPersistence.Object);
            //act
            something3Interactor.CreateSomething3();
            //assert
            mockPersistence.Verify(x => x.SaveSomething3(something3));
        }
        [Fact]
        public void CreateSomething3__PersistsSomething3WithFullName()
        {
            //arrange
            var mockSomething3Factory = new Mock<ISomething3Factory>();
            var fullName = "Fred Bloggs";
            var something3 = new Core.Model.Something3()
            {
                FullName = fullName
            };
            mockSomething3Factory.Setup(x => x.Create(fullName)).Returns(something3);
            var mockPersistence = new Mock<IClassLibraryPersistence>();
            Something3Interactor something3Interactor = new Something3Interactor(mockSomething3Factory.Object, mockPersistence.Object);
            //act
            something3Interactor.CreateSomething3(fullName);
            //assert
            mockPersistence.Verify(x => x.SaveSomething3(something3));
        }

        [Fact]
        public void HomeController__GetThings__ReturnsListOfSomething3WithId()
        {
            var mockInteractor = new Mock<Something3Interactor>();
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
                Equal(something3.FullName, results[0].FullName);
                Equal(expectedId, results[0].Id);
            }
        }
    }
}