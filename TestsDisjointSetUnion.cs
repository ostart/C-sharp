using AlgorithmsDataStructures4;
using NUnit.Framework;

namespace AlgoritmTests
{
    [TestFixture]
    public class DsuTest
    {
        [Test]
        public void UnionTest()
        {
            var dsu = new DSU<int>();
            dsu.MakeSet(1);
            dsu.MakeSet(2);

            dsu.Unite(1, 2, true);

            Assert.That(dsu.Find(1), Is.EqualTo(dsu.Find(2)));
        }

        [Test]
        public void UnionTest2()
        {
            var dsu = new DSU<int>();
            dsu.MakeSet(1);
            dsu.MakeSet(2);
            dsu.MakeSet(3);
            dsu.MakeSet(4);
            dsu.MakeSet(5);

            Assert.AreEqual(4, dsu.Find(4));


            dsu.Unite(1, 4, true);
            dsu.Unite(3, 5, true);

            Assert.AreEqual(1, dsu.Find(4));
            Assert.AreEqual(1, dsu.Find(1));
            Assert.AreEqual(2, dsu.Find(2));
            Assert.AreEqual(3, dsu.Find(5));
            Assert.AreEqual(3, dsu.Find(3));

            dsu.Unite(5, 2, true);

            Assert.AreEqual(3, dsu.Find(5));
            Assert.AreEqual(3, dsu.Find(3));
            Assert.AreEqual(3, dsu.Find(2));
        }
    }
}