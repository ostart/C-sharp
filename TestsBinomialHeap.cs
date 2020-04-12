using NUnit.Framework;
using System.Collections.Generic;
using AlgorithmsDataStructures4;

namespace Tests
{
    public class TestsBinomialHeap
    {
        [Test]
        public static void TestBinomialHeapCreation()
        {
            var heap = new BinomialHeap();
            heap.Add(2);
            Assert.AreEqual(heap.Roots.Count, 1);
            heap.Add(3);
            Assert.AreEqual(heap.Roots.Count, 1);
            heap.Add(1);
            Assert.AreEqual(heap.Roots.Count, 2);
            heap.Add(4);
            Assert.AreEqual(heap.Roots.Count, 1);
            heap.Add(2);
            Assert.AreEqual(heap.Roots.Count, 2);
            heap.Add(5);
            Assert.AreEqual(heap.Roots.Count, 2);
            heap.Add(6);
            Assert.AreEqual(heap.Roots.Count, 3);
            heap.Add(7);
            Assert.AreEqual(heap.Roots.Count, 1);
            Assert.IsNotNull(heap.Roots[3]);
            var max = heap.GetMaximum();
            Assert.AreEqual(max, 7);
        }
    }
}