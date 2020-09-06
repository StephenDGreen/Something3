using Moq;
using Something3.Core.Services;
using Something3.Core.ViewModel;
using System.Collections.Generic;
using Xunit;
using static Xunit.Assert;

namespace Something3.API.Services.Tests
{
    public class Something3DisplayInteractorTests
    {
        [Fact]
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
            Equal(something3.Count, something.Count);
            Equal(something3[something3.Count - 1].FullName, something[something.Count - 1].FullName);
        }
    }
}