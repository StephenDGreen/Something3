using Moq;
using Something3.API.Services;
using Something3.Core.Services;
using Something3.Core.ViewModel;
using Something3.Database.Services;
using Something3.DatabaseTests.Infrastructure.Factories;
using System.Collections.Generic;
using Xunit;
using static Xunit.Assert;

namespace Something3.IntegrationTests
{
    public class IntegrationTests
    {

        [Fact]
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
                var interactor = new Something3DisplayInteractor(persistence);

                List<Something3WithId> results = interactor.GetThings();
                Equal(something3.FullName, results[0].FullName);
                Equal(expectedId, results[0].Id);
            }
        }
    }
}
