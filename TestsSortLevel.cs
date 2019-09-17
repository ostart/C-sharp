using System.Collections.Generic;
using NUnit.Framework;
using SortSpace;

namespace Tests
{
    class TestsSortLevel
    {
        private static int[] _array;

        [SetUp]
        public void TestsSetup()
        {
            _array = new int[] {4,3,1,2};
        }

        [TearDown]
        public void TestsTeardown()
        {
            _array = null;
        }

        [Test]
        public static void TestSelectionSortStep()
        {
            SortLevel.SelectionSortStep(_array, 0);
            var ethalon = new int[] {1,3,4,2};
            Assert.AreEqual(ethalon.Length, _array.Length);
            for (int i = 0; i < _array.Length; i++)
            {
                Assert.AreEqual(ethalon[i], _array[i]);
            }
        }

        [Test]
        public static void TestBubbleSortStep()
        {
            var result = SortLevel.BubbleSortStep(_array);
            var ethalon = new int[] {3,1,2,4};
            Assert.IsFalse(result);
            Assert.AreEqual(ethalon.Length, _array.Length);
            for (int i = 0; i < _array.Length; i++)
            {
                Assert.AreEqual(ethalon[i], _array[i]);
            }
        }
    }
}