using Something3.Core;
using Something3.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Something3.CoreTests
{
    [TestClass()]
    public class Something3FactoryTests
    {
        [TestMethod()]
        public void Create_CreatesSomething3()
        {
            //arrange
            Something3Factory something3Factory = new Something3Factory();

            //act
            var actual = something3Factory.Create();
            //assert
            Assert.IsInstanceOfType(actual, typeof(Core.Model.Something3));
        }
        [TestMethod()]
        public void Create_CreatesSomething3WithFullname()
        {
            //arrange
            Something3Factory something3Factory = new Something3Factory();
            var expected = "Fred Bloggs";

            //act
            var actual = something3Factory.Create(expected);
            //assert
            Assert.IsInstanceOfType(actual, typeof(Core.Model.Something3));
            Assert.AreEqual(actual.FullName, expected);
        }
    }
}