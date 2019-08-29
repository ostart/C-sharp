using NUnit.Framework;
using AlgorithmsDataStructures2;
using System.Linq;

namespace Tests
{
    class TestsHeap
    {
        [Test]
        public void TestMakeHeap()
        {
            var heap = new Heap();
            var arr = new int[] {8,7,4,9,11,6,5,2,1,3,-1,-1,-1,-1,-1};
            heap.MakeHeap(arr, 3);
            Assert.AreEqual(15, heap.HeapArray.Length);
            var max = heap.HeapArray.Max();
            Assert.AreEqual(max, heap.HeapArray[0]);
            CheckArray(heap.HeapArray, 0);
        }

        private void CheckArray(int[] array, int index)
        {
            var left = 2*index + 1;
            var right = 2*index + 2;
            if(left >= array.Length) return;
            Assert.GreaterOrEqual(array[index], array[left]);
            Assert.GreaterOrEqual(array[index], array[right]);
            CheckArray(array, left);
            CheckArray(array, right);
        }

        [Test]
        public void TestGetMax()
        {
            var heap = new Heap();
            var arr = new int[] {8,7,4,9,11,6,5,2,1,3,15,10,14,12,13};
            heap.MakeHeap(arr, 3);
            Assert.AreEqual(15, heap.HeapArray.Length);
            var max = heap.GetMax();
            Assert.AreEqual(15, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(14, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(13, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(12, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(11, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(10, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(9, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(8, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(7, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(6, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(5, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(4, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(3, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(2, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(1, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(-1, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(-1, max);
            CheckArray(heap.HeapArray, 0);
            Assert.IsTrue(heap.Add(11));
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(11, max);
            CheckArray(heap.HeapArray, 0);
            max = heap.GetMax();
            Assert.AreEqual(-1, max);
            CheckArray(heap.HeapArray, 0);
        }

        [Test]
        public void TestAdd()
        {
            var heap = new Heap();
            var arr = new int[] {8,7,4,9,11,6,5,2,1,3,-1,-1,-1,-1,-1};
            heap.MakeHeap(arr, 3);
            Assert.AreEqual(15, heap.HeapArray.Length);
            Assert.IsTrue(heap.Add(10));
            CheckArray(heap.HeapArray, 0);
            Assert.IsTrue(heap.Add(12));
            CheckArray(heap.HeapArray, 0);
            Assert.IsTrue(heap.Add(15));
            CheckArray(heap.HeapArray, 0);
            Assert.IsTrue(heap.Add(14));
            CheckArray(heap.HeapArray, 0);
            Assert.IsTrue(heap.Add(13));
            CheckArray(heap.HeapArray, 0);
            var max = heap.GetMax();
            Assert.AreEqual(15, max);
            CheckArray(heap.HeapArray, 0);
            Assert.IsTrue(heap.Add(14));
            CheckArray(heap.HeapArray, 0);
            Assert.IsFalse(heap.Add(17));
            CheckArray(heap.HeapArray, 0);
        }
    }
}