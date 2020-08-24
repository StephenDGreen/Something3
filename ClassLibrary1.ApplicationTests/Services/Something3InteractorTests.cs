using ClassLibrary1.Core;
using ClassLibrary1.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClassLibrary1.Application.Services.Tests
{
    [TestClass()]
    public class Something3InteractorTests
    {
        [TestMethod()]
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
        [TestMethod()]
        public void CreateSomething3__PersistsSomething3()
        {
            //arrange
            var mockSomething3Factory = new Mock<ISomething3Factory>();
            var something3 = new Something3();
            mockSomething3Factory.Setup(x => x.Create()).Returns(something3);
            var mockPersistence = new Mock<IClassLibraryPersistence>();
            Something3Interactor something3Interactor = new Something3Interactor(mockSomething3Factory.Object, mockPersistence.Object);
            //act
            something3Interactor.CreateSomething3();
            //assert
            mockPersistence.Verify(x => x.SaveSomething3(something3));
        }
    }
}