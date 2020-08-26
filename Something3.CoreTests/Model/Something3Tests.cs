using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Something3.Core.Model.Tests
{
    [TestClass()]
    public partial class Something3Tests
    {
        private Something3 something = new Something3
        {
            FullName = "Bilbo Baggins"
        };

        [TestMethod()]
        public void HasFullname()
        {
            //arrange
            string expected = "Bilbo Baggins";

            //act
            string actual = something.FullName;
            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}