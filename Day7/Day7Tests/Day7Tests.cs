using Day7;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day7Tests
{
    [TestClass]
    public class Day7Tests
    {
        [TestMethod]
        public void TestAssignment()
        {
            var bag = new Bag("light red bags contain 1 bright white bag, 2 muted yellow bags.");
            Assert.AreEqual(bag.Description, "light red bag");
            Assert.AreEqual(2, bag.Contents.Count);
            Assert.AreEqual(1, bag.Contents["bright white bag"]);
            Assert.AreEqual(2, bag.Contents["muted yellow bag"]);

            bag = new Bag("dark orange bags contain 3 bright white bags, 4 muted yellow bags.");
            Assert.AreEqual(bag.Description, "dark orange bag");
            Assert.AreEqual(2, bag.Contents.Count);
            Assert.AreEqual(3, bag.Contents["bright white bag"]);
            Assert.AreEqual(4, bag.Contents["muted yellow bag"]);

            bag = new Bag("bright white bags contain 1 shiny gold bag."); 
            Assert.AreEqual(bag.Description, "bright white bag");
            Assert.AreEqual(1, bag.Contents.Count);
            Assert.AreEqual(1, bag.Contents["shiny gold bag"]);

            bag = new Bag("muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.");
            Assert.AreEqual(bag.Description, "muted yellow bag");
            Assert.AreEqual(2, bag.Contents.Count);
            Assert.AreEqual(2, bag.Contents["shiny gold bag"]);
            Assert.AreEqual(9, bag.Contents["faded blue bag"]);

            bag = new Bag("shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.");
            Assert.AreEqual(bag.Description, "shiny gold bag");
            Assert.AreEqual(2, bag.Contents.Count);
            Assert.AreEqual(1, bag.Contents["dark olive bag"]);
            Assert.AreEqual(2, bag.Contents["vibrant plum bag"]);

            bag = new Bag("dark olive bags contain 3 faded blue bags, 4 dotted black bags.");
            Assert.AreEqual(bag.Description, "dark olive bag");
            Assert.AreEqual(2, bag.Contents.Count);
            Assert.AreEqual(3, bag.Contents["faded blue bag"]);
            Assert.AreEqual(4, bag.Contents["dotted black bag"]);

            bag = new Bag("vibrant plum bags contain 5 faded blue bags, 6 dotted black bags."); 
            Assert.AreEqual(bag.Description, "vibrant plum bag");
            Assert.AreEqual(2, bag.Contents.Count);
            Assert.AreEqual(5, bag.Contents["faded blue bag"]);
            Assert.AreEqual(6, bag.Contents["dotted black bag"]);

            bag = new Bag("faded blue bags contain no other bags.");
            Assert.AreEqual(bag.Description, "faded blue bag");
            Assert.AreEqual(0, bag.Contents.Count);

            bag = new Bag("dotted black bags contain no other bags.");
            Assert.AreEqual(bag.Description, "dotted black bag");
            Assert.AreEqual(0, bag.Contents.Count);
        }

        [TestMethod]
        public void TestHasBag()
        {
            var bag = new Bag("bright white bags contain 1 shiny gold bag.");
            Assert.IsTrue(bag.HasBag("shiny gold bag"));

            bag = new Bag("muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.");
            Assert.IsTrue(bag.HasBag("shiny gold bag"));
        }

        [TestMethod]
        public void BagsInsideSmallTest()
        {
            string[] data = new[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            };

            var bags = new AllBags(data);
            Assert.AreEqual(32, bags.BagsInside("shiny gold bag") -1);
        }

        [TestMethod]
        public void BagsInsideSecondTest()
        {
            string[] data = new[]
            {
                "shiny gold bags contain 2 dark red bags.",
                "dark red bags contain 2 dark orange bags.",
                "dark orange bags contain 2 dark yellow bags.",
                "dark yellow bags contain 2 dark green bags.",
                "dark green bags contain 2 dark blue bags.",
                "dark blue bags contain 2 dark violet bags.",
                "dark violet bags contain no other bags."
            };
            var bags = new AllBags(data);
            Assert.AreEqual(126, bags.BagsInside("shiny gold bag") - 1);
        }
    }
}