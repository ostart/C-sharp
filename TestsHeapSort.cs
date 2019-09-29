using System.Collections.Generic;
using NUnit.Framework;
using SortSpace;

namespace Tests
{
    class TestsHeapSort
    {
        [Test]
        public static void TestHeapSort()
        {
            var array = new int[] {3,5,2,4,1};
            var heap = new HeapSort(array);
            var max = heap.GetNextMax();
            Assert.AreEqual(5, max);
            max = heap.GetNextMax();
            Assert.AreEqual(4, max);
            max = heap.GetNextMax();
            Assert.AreEqual(3, max);
            max = heap.GetNextMax();
            Assert.AreEqual(2, max);
            max = heap.GetNextMax();
            Assert.AreEqual(1, max);
            max = heap.GetNextMax();
            Assert.AreEqual(-1, max);
            max = heap.GetNextMax();
            Assert.AreEqual(-1, max);
        }
    }
}