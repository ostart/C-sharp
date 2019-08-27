using NUnit.Framework;
using AlgorithmsDataStructures2;
using System.Linq;
using System;

namespace Tests
{
    class TestsHeap
    {
        [Test]
        public void TestMakeHeap()
        {
            var heap = new Heap();
            var arr = new int[] {8,7,4,9,11,6,5,2,1,3};
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
            var arr = new int[] {8,7,4,9,11,6,5,2,1,3};
            heap.MakeHeap(arr, 3);
            Assert.AreEqual(15, heap.HeapArray.Length);
            var max = heap.GetMax();
            Assert.AreEqual(11, max);
            CheckArray(heap.HeapArray, 0);
        }

        [Test]
        public void TestAdd()
        {
            var heap = new Heap();
            var arr = new int[] {8,7,4,9,11,6,5,2,1,3};
            heap.MakeHeap(arr, 3);
            Assert.AreEqual(15, heap.HeapArray.Length);
            Assert.IsTrue(heap.Add(10));
            CheckArray(heap.HeapArray, 0);
        }
    }
}