using Moq;
using Something3.Core;
using Xunit;

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
    }
}