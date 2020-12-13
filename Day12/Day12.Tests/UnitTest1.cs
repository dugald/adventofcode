using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day12.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNavigator()
        {
            var input = new string[]
            {
                "F10",
                "N3",
                "F7",
                "R90",
                "F11"
            };
            var navigator = new Navigator(input);

            navigator.ProcessInstructions();

            //Assert.AreEqual(25, navigator.Distance);
            Assert.AreEqual(286, navigator.Distance);
        }
    }
}