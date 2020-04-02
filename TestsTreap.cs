using NUnit.Framework;
using System.Collections.Generic;
using AlgorithmsDataStructures4;

namespace Tests
{
    public class TestsTreap
    {
        [Test]
        public static void TestTreapCreation()
        {
            var init = new List<int[]>
            {
                new int[] {7,10},
                new int[] {4,6},
                new int[] {13,8},
                new int[] {2,4},
                new int[] {3,3},
                new int[] {0,3},
                new int[] {11,3},
                new int[] {5,1},
                new int[] {14,4},
                new int[] {9,7},
                new int[] {6,2}
            };
            var treap = new Treap(init);

            Assert.AreEqual(treap.Root.Key, 7);
            Assert.AreEqual(treap.Root.Priority, 10);

            Assert.AreEqual(treap.Root.LeftChild.Key, 4);
            Assert.AreEqual(treap.Root.LeftChild.Priority, 6);

            Assert.AreEqual(treap.Root.RightChild.Key, 13);
            Assert.AreEqual(treap.Root.RightChild.Priority, 8);

            Assert.AreEqual(treap.Root.RightChild.LeftChild.Key, 9);
            Assert.AreEqual(treap.Root.RightChild.LeftChild.Priority, 7);

            Assert.IsNull(treap.Root.RightChild.LeftChild.LeftChild);
            
            Assert.AreEqual(treap.Root.RightChild.LeftChild.RightChild.Key, 11);
            Assert.AreEqual(treap.Root.RightChild.LeftChild.RightChild.Priority, 3);
        }
    }
}