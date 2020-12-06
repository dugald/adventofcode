using Day6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day6Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestScore()
        {
            var group = new Group();
            group.Persons.Add(new Person("abc"));
            Assert.AreEqual(3, group.Count());

            group = new Group();
            group.Persons.Add(new Person("a"));
            group.Persons.Add(new Person("b"));
            group.Persons.Add(new Person("c"));
            Assert.AreEqual(3, group.Count());

            group = new Group();
            group.Persons.Add(new Person("ab"));
            group.Persons.Add(new Person("ac"));
            Assert.AreEqual(3, group.Count());

            group = new Group();
            group.Persons.Add(new Person("a"));
            group.Persons.Add(new Person("a"));
            group.Persons.Add(new Person("a"));
            Assert.AreEqual(1, group.Count());

            group = new Group();
            group.Persons.Add(new Person("b"));
            Assert.AreEqual(1, group.Count());
        }

        [TestMethod]
        public void TestScoreMethod2()
        {
            var group = new Group();
            group.Persons.Add(new Person("abc"));
            Assert.AreEqual(3, group.Count());

            group = new Group();
            group.Persons.Add(new Person("a"));
            group.Persons.Add(new Person("b"));
            group.Persons.Add(new Person("c"));
            Assert.AreEqual(0, group.Count());

            group = new Group();
            group.Persons.Add(new Person("ab"));
            group.Persons.Add(new Person("ac"));
            Assert.AreEqual(1, group.Count());

            group = new Group();
            group.Persons.Add(new Person("a"));
            group.Persons.Add(new Person("a"));
            group.Persons.Add(new Person("a"));
            Assert.AreEqual(1, group.Count());

            group = new Group();
            group.Persons.Add(new Person("b"));
            Assert.AreEqual(1, group.Count());
        }
    }
}
