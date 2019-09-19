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

        [Test]
        public static void TestInsertionSortStep()
        {
            var array = new int[] {7,6,5,4,3,2,1};
            SortLevel.InsertionSortStep(array, 3, 0);
            var ethalon = new int[] {1,6,5,4,3,2,7};
            Assert.AreEqual(ethalon.Length, array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(ethalon[i], array[i]);
            }
            SortLevel.InsertionSortStep(array, 3, 1);
            var ethalon2 = new int[] {1,3,5,4,6,2,7};
            Assert.AreEqual(ethalon2.Length, array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(ethalon2[i], array[i]);
            }
        }

        [Test]
        public static void TestKnuthSequence()
        {
            var result = SortLevel.KnuthSequence(15);
            var ethalon = new List<int> {13, 4, 1};
            Assert.AreEqual(ethalon.Count, result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(ethalon[i], result[i]);
            }
        }
    }
}