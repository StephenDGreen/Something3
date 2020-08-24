using ClassLibrary1.Core;
using ClassLibrary1.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ClassLibrary1.Application.Services.Tests
{
    [TestClass()]
    public class Something3DisplayInteractorTests
    {

        [TestMethod()]
        public void DisplaySomething3__DisplaysSomething3()
        {
            //arrange
            var something3 = new List<Something3>();
            something3.Add(new Something3 { FullName = "Fred Bloggs" });
            var mockPersistence = new Mock<IClassLibraryPersistence>();
            mockPersistence.Setup(x => x.GetSomething3List()).Returns(something3);
            Something3DisplayInteractor interactor = new Something3DisplayInteractor(mockPersistence.Object);
            //act
            List<Something3> something = interactor.GetSomething3List();
            AreEqual(something3.Count, something.Count);
            AreEqual(something3[something3.Count-1].FullName, something[something.Count-1].FullName);
        }
    }
}