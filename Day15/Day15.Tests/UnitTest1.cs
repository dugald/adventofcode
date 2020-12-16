using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day15.Tests
{
    [TestClass]
    public class Day15Tests
    {
        [TestMethod]
        public void TestSeed()
        {
            var game = new CountingGame();
            var input = new List<int> {0, 3, 6};

            game.Seed(input);

            CollectionAssert.AreEqual(input.ToArray(), game.NumbersSpoken);
        }

        [TestMethod]
        public void TestNextNumber()
        {
            var game = new CountingGame();
            var input = new List<int> { 0, 3, 6 };

            game.Seed(input);

            Assert.AreEqual(0, game.GetNextNumber());
            Assert.AreEqual(3, game.GetNextNumber());
            Assert.AreEqual(3, game.GetNextNumber());
            Assert.AreEqual(1, game.GetNextNumber());
            Assert.AreEqual(0, game.GetNextNumber());
            Assert.AreEqual(4, game.GetNextNumber());
            Assert.AreEqual(0, game.GetNextNumber());
        }

        [DataTestMethod]
        [DataRow(2020, 436, new int[] { 0, 3, 6 })]
        [DataRow(2020, 1, new int[] { 1, 3, 2 })]
        [DataRow(2020, 10, new int[] { 2, 1, 3 })]
        [DataRow(2020, 27, new int[] { 1, 2, 3 })]
        [DataRow(2020, 78, new int[] { 2, 3, 1 })]
        [DataRow(2020, 438, new int[] { 3, 2, 1 })]
        [DataRow(2020, 1836, new int[] { 3, 1, 2 })]
        [DataRow(2020, 758, new int[] { 2, 20, 0, 4, 1, 17 })]
        [DataRow(30000000, 175594, new int[] { 0, 3, 6 })]
        public void TestGetXthNumber(int position, int expected, int[] seedData)
        {
            var game = new CountingGame();
            game.Seed(seedData.ToList());

            Assert.AreEqual(expected, game.GetXthNumber(position));
        }
    }
}