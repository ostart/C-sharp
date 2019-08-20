using NUnit.Framework;
using AlgorithmsDataStructures2;

namespace Tests
{
    class Tests_aBST
    {
        private aBST _tree;

        [SetUp]
        public void TestsSetup()
        {
            _tree = new aBST(3);
            _tree.Tree = new int?[] {50, 25, 75, null, 37, 62, 84, null, null, 31, 43, 55, null, null, 92};
        }

        [TearDown]
        public void TestsTeardown()
        {
            _tree = null;
        }
		
		[Test]
        public void TestTreeCount()
        {
            var tree0 = new aBST(0);
            Assert.AreEqual(1, tree0.Tree.Length);

            var tree1 = new aBST(1);
            Assert.AreEqual(3, tree1.Tree.Length);

            var tree2 = new aBST(2);
            Assert.AreEqual(7, tree2.Tree.Length);

            var tree3 = new aBST(3);
            Assert.AreEqual(15, tree3.Tree.Length);
        }

        [Test]
        public void TestFindKeyIndex()
        {
            Assert.AreEqual(0, _tree.FindKeyIndex(50));
            Assert.AreEqual(1, _tree.FindKeyIndex(25));
            Assert.AreEqual(2, _tree.FindKeyIndex(75));
            Assert.AreEqual(4, _tree.FindKeyIndex(37));
            Assert.AreEqual(5, _tree.FindKeyIndex(62));
            Assert.AreEqual(6, _tree.FindKeyIndex(84));
            Assert.AreEqual(9, _tree.FindKeyIndex(31));
            Assert.AreEqual(10, _tree.FindKeyIndex(43));
            Assert.AreEqual(11, _tree.FindKeyIndex(55));
            Assert.AreEqual(14, _tree.FindKeyIndex(92));

            Assert.AreEqual(-3, _tree.FindKeyIndex(24));
            Assert.AreEqual(-12, _tree.FindKeyIndex(63));
            Assert.AreEqual(-13, _tree.FindKeyIndex(83));
        }

        [Test]
        public void TestAddKey()
        {
            Assert.AreEqual(0, _tree.AddKey(50));
            Assert.AreEqual(1, _tree.AddKey(25));
            Assert.AreEqual(5, _tree.AddKey(62));
            Assert.AreEqual(14, _tree.AddKey(92));
            Assert.AreEqual(3, _tree.AddKey(24));
            Assert.AreEqual(13, _tree.AddKey(83));
        }
    }
}