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

        [Test]
        public static void TestShellSort()
        {
            var array = new int[] {15,14,13,12,11,10,9,8,7,6,5,4,3,2,1};
            SortLevel.ShellSort(array);
            var ethalon = new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
            Assert.AreEqual(ethalon.Length, array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(ethalon[i], array[i]);
            }
        }

        [Test]
        public static void TestArrayChunk()
        {
            var array = new int[] {7,5,6,4,3,1,2};
            var referenceValueIndex = SortLevel.ArrayChunk(array);
            Assert.AreEqual(3, referenceValueIndex);
            var ethalon = new int[] {2,1,3,4,6,5,7};
            Assert.AreEqual(ethalon.Length, array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(ethalon[i], array[i]);
            }

            var array2 = new int[] {4,5,6,7,3,1,2};
            var referenceValueIndex2 = SortLevel.ArrayChunk(array2);
            Assert.AreEqual(6, referenceValueIndex2);
            var ethalon2 = new int[] {4,5,6,2,3,1,7};
            Assert.AreEqual(ethalon2.Length, array2.Length);
            for (int i = 0; i < array2.Length; i++)
            {
                Assert.AreEqual(ethalon2[i], array2[i]);
            }

            var array3 = new int[] {4,5,6,3,1,2};
            var referenceValueIndex3 = SortLevel.ArrayChunk(array3);
            Assert.AreEqual(5, referenceValueIndex3);
            var ethalon3 = new int[] {2,1,3,4,5,6};
            Assert.AreEqual(ethalon3.Length, array3.Length);
            for (int i = 0; i < array3.Length; i++)
            {
                Assert.AreEqual(ethalon3[i], array3[i]);
            }

            var array4 = new int[] {1,3,4,6,5,2,8};
            var referenceValueIndex4 = SortLevel.ArrayChunk(array4);
            Assert.AreEqual(5, referenceValueIndex4);
            var ethalon4 = new int[] {1,3,4,2,5,6,8};
            Assert.AreEqual(ethalon4.Length, array4.Length);
            for (int i = 0; i < array4.Length; i++)
            {
                Assert.AreEqual(ethalon4[i], array4[i]);
            }

            var array5 = new int[] {1,2,7,4,5};
            var referenceValueIndex5 = SortLevel.ArrayChunk(array5);
            Assert.AreEqual(4, referenceValueIndex5);
            var ethalon5 = new int[] {1,2,5,4,7};
            Assert.AreEqual(ethalon5.Length, array5.Length);
            for (int i = 0; i < array5.Length; i++)
            {
                Assert.AreEqual(ethalon5[i], array5[i]);
            }
        }

        [Test]
        public static void TestArrayChunkLeftRight()
        {
            var array = new int[] {7,5,6,4,3,1,2};
            var referenceValueIndex = SortLevel.ArrayChunk(array, 0, 6);
            Assert.AreEqual(3, referenceValueIndex);
            var ethalon = new int[] {2,1,3,4,6,5,7};
            Assert.AreEqual(ethalon.Length, array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(ethalon[i], array[i]);
            }

            var array2 = new int[] {4,5,6,7,3,1,2};
            var referenceValueIndex2 = SortLevel.ArrayChunk(array2, 0, 6);
            Assert.AreEqual(6, referenceValueIndex2);
            var ethalon2 = new int[] {4,5,6,2,3,1,7};
            Assert.AreEqual(ethalon2.Length, array2.Length);
            for (int i = 0; i < array2.Length; i++)
            {
                Assert.AreEqual(ethalon2[i], array2[i]);
            }

            var array3 = new int[] {4,5,6,3,1,2};
            var referenceValueIndex3 = SortLevel.ArrayChunk(array3, 0, 5);
            Assert.AreEqual(5, referenceValueIndex3);
            var ethalon3 = new int[] {2,1,3,4,5,6};
            Assert.AreEqual(ethalon3.Length, array3.Length);
            for (int i = 0; i < array3.Length; i++)
            {
                Assert.AreEqual(ethalon3[i], array3[i]);
            }

            var array4 = new int[] {1,3,4,6,5,2,8};
            var referenceValueIndex4 = SortLevel.ArrayChunk(array4, 0, 6);
            Assert.AreEqual(5, referenceValueIndex4);
            var ethalon4 = new int[] {1,3,4,2,5,6,8};
            Assert.AreEqual(ethalon4.Length, array4.Length);
            for (int i = 0; i < array4.Length; i++)
            {
                Assert.AreEqual(ethalon4[i], array4[i]);
            }

            var array5 = new int[] {1,2,7,4,5};
            var referenceValueIndex5 = SortLevel.ArrayChunk(array5, 0, 4);
            Assert.AreEqual(4, referenceValueIndex5);
            var ethalon5 = new int[] {1,2,5,4,7};
            Assert.AreEqual(ethalon5.Length, array5.Length);
            for (int i = 0; i < array5.Length; i++)
            {
                Assert.AreEqual(ethalon5[i], array5[i]);
            }

            var array6 = new int[] {1,2,7,4,5};
            var referenceValueIndex6 = SortLevel.ArrayChunk(array6, 1, 3);
            Assert.AreEqual(2, referenceValueIndex6);
            var ethalon6 = new int[] {1,2,4,7,5};
            Assert.AreEqual(ethalon6.Length, array6.Length);
            for (int i = 0; i < array6.Length; i++)
            {
                Assert.AreEqual(ethalon6[i], array6[i]);
            }
        }

        [Test]
        public static void TestQuickSort()
        {
            var array = new int[] {15,14,13,12,11,10,9,8,7,6,5,4,3,2,1};
            SortLevel.QuickSort(array, 0, 14);
            var ethalon = new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
            Assert.AreEqual(ethalon.Length, array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(ethalon[i], array[i]);
            }

            var array2 = new int[] {10,14,3,12,11,1,9,15,7,6,5,4,13,2,8};
            SortLevel.QuickSort(array2, 0, 14);
            var ethalon2 = new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
            Assert.AreEqual(ethalon2.Length, array2.Length);
            for (int i = 0; i < array2.Length; i++)
            {
                Assert.AreEqual(ethalon2[i], array2[i]);
            }
        }
    }
}