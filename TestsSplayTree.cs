using NUnit.Framework;
using AlgorithmsDataStructures4;

namespace Tests
{
    public class TestsSplayTree
    {
        [Test]
        public static void TestSplayOperations()
        {
            var init = new int [] {8,3,10,1,6,4,7,14,13};
            var splayTree = new SplayTree(init);

            var result = splayTree.Find(6);
            Assert.AreEqual(result.Value, 6);
            Assert.AreEqual(splayTree.Root.Value, 6);
            
            splayTree.Remove(10);
            var resultRemove = splayTree.Find(10);
            Assert.IsNull(resultRemove);
            Assert.AreEqual(splayTree.Root.Value, 8);

            splayTree.Add(12);
            Assert.AreEqual(splayTree.Root.Value, 12);
            Assert.AreEqual(splayTree.Root.LeftChild.Value, 8);
            Assert.AreEqual(splayTree.Root.RightChild.Value, 13);
        }
    }
}