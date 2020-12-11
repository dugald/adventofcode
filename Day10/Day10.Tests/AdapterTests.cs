using System;
using NUnit;
using NUnit.Framework;

namespace Day10.Tests
{
    [TestFixture]
    public class AdapterTests
    {
        [Test]
        public void TestSmallExample()
        {
            string[] input = {"16","10","15","5","1","11","7","19","6","12","4" };
            var adapters = new AdapterList(input);
            adapters.TraverseAdapters();
            Assert.AreEqual(7, adapters.OneJolts);
            Assert.AreEqual(5, adapters.ThreeJolts);
        }

        [Test]
        public void LargerTestExample()
        {
            string[] input = { "28", "33", "18", "42", "31", "14", "46", "20", "48", "47", "24","23","49","45","19","38","39","11","1","32","25","35","8","17","7","9","4","2","34","10","3" };
            var adapters = new AdapterList(input);
            adapters.TraverseAdapters();
            Assert.AreEqual(22, adapters.OneJolts);
            Assert.AreEqual(10, adapters.ThreeJolts);
        }

        [Test]
        public void TestSmallArrangements()
        {
            string[] input = { "16", "10", "15", "5", "1", "11", "7", "19", "6", "12", "4" };
            var adapters = new AdapterList(input);
            Assert.AreEqual(8, adapters.JoltagesArrangements());
        }

        [Test]
        public void TestLargeArrangement()
        {
            string[] input = { "28", "33", "18", "42", "31", "14", "46", "20", "48", "47", "24", "23", "49", "45", "19", "38", "39", "11", "1", "32", "25", "35", "8", "17", "7", "9", "4", "2", "34", "10", "3" };
            var adapters = new AdapterList(input);
            Assert.AreEqual(19208, adapters.JoltagesArrangements());
        }
    }
}