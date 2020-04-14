using NUnit.Framework;
using System.Collections.Generic;
using AlgorithmsDataStructures4;

namespace Tests
{
    public class TestsSkewHeap
    {
        [Test]
        public static void TestSkewHeapCreation()
        {
            var heap1 = new SkewHeap();
            heap1.Add(1);
            heap1.Add(23);
            heap1.Add(4);
            heap1.Add(28);
            heap1.Add(24);
            heap1.Add(44);
            heap1.Add(63);
            Assert.AreEqual(heap1.Root.Value, 1);

            Assert.AreEqual(heap1.Root.LeftChild.Value, 4);
            Assert.AreEqual(heap1.Root.LeftChild.LeftChild.Value, 63);
            Assert.AreEqual(heap1.Root.LeftChild.RightChild.Value, 24);
            Assert.AreEqual(heap1.Root.RightChild.Value, 23);
            Assert.AreEqual(heap1.Root.RightChild.LeftChild.Value, 44);
            Assert.AreEqual(heap1.Root.RightChild.RightChild.Value, 28);
        }

        [Test]
        public static void TestSkewHeapMergeAndRemove()
        {
            var heap1 = new SkewHeap();
            heap1.Add(1);
            heap1.Add(23);
            heap1.Add(4);
            heap1.Add(28);
            heap1.Add(24);
            heap1.Add(44);
            heap1.Add(63);
            Assert.AreEqual(heap1.Root.Value, 1);

            var heap2 = new SkewHeap();
            heap2.Add(13);
            heap2.Add(99);
            heap2.Add(17);
            heap2.Add(201);
            heap2.Add(49);
            heap2.Add(105);
            heap2.Add(57);
            Assert.AreEqual(heap2.Root.Value, 13);

            var heap = new SkewHeap();
            heap.Root = heap.Merge(heap1.Root, heap2.Root);
            Assert.AreEqual(heap.Root.Value, 1);

            heap.Remove();
            Assert.AreEqual(heap.Root.Value, 4);
        }
    }
}