using System.Collections.Generic;
using NUnit.Framework;
using SortSpace;

namespace Tests
{
    class TestsBinarySearch
    {
        [Test]
        public static void TestStepAndResult1()
        {
            var binarySearch = new BinarySearch(new[] {1,2,3,4,5,6,7});
            binarySearch.Step(5);
            Assert.AreEqual(6, binarySearch.Right);
            Assert.AreEqual(4, binarySearch.Left);
            Assert.AreEqual(0, binarySearch.GetResult());

            binarySearch.Step(5);
            Assert.AreEqual(4, binarySearch.Right);
            Assert.AreEqual(4, binarySearch.Left);
            Assert.AreEqual(0, binarySearch.GetResult());

            binarySearch.Step(5);
            Assert.AreEqual(4, binarySearch.Right);
            Assert.AreEqual(4, binarySearch.Left);
            Assert.AreEqual(1, binarySearch.GetResult());
        }

        [Test]
        public static void TestStepAndResult2()
        {
            var binarySearch = new BinarySearch(new[] {1,2,3,4,5,6,7});
            binarySearch.Step(3);
            Assert.AreEqual(2, binarySearch.Right);
            Assert.AreEqual(0, binarySearch.Left);
            Assert.AreEqual(0, binarySearch.GetResult());

            binarySearch.Step(3);
            Assert.AreEqual(2, binarySearch.Right);
            Assert.AreEqual(2, binarySearch.Left);
            Assert.AreEqual(0, binarySearch.GetResult());

            binarySearch.Step(3);
            Assert.AreEqual(2, binarySearch.Right);
            Assert.AreEqual(2, binarySearch.Left);
            Assert.AreEqual(1, binarySearch.GetResult());
        }

        [Test]
        public static void TestStepAndResult3()
        {
            var binarySearch = new BinarySearch(new[] {1,2,3,4,5,6});
            binarySearch.Step(5);
            Assert.AreEqual(5, binarySearch.Right);
            Assert.AreEqual(3, binarySearch.Left);
            Assert.AreEqual(0, binarySearch.GetResult());

            binarySearch.Step(5);
            Assert.AreEqual(4, binarySearch.Right);
            Assert.AreEqual(4, binarySearch.Left);
            Assert.AreEqual(1, binarySearch.GetResult());

            binarySearch.Step(5);
            Assert.AreEqual(4, binarySearch.Right);
            Assert.AreEqual(4, binarySearch.Left);
            Assert.AreEqual(1, binarySearch.GetResult());
        }

        [Test]
        public static void TestStepAndResult4()
        {
            var binarySearch = new BinarySearch(new[] {1,2,3,4,5,6});
            binarySearch.Step(2);
            Assert.AreEqual(1, binarySearch.Right);
            Assert.AreEqual(0, binarySearch.Left);
            Assert.AreEqual(0, binarySearch.GetResult());

            binarySearch.Step(2);
            Assert.AreEqual(1, binarySearch.Right);
            Assert.AreEqual(1, binarySearch.Left);
            Assert.AreEqual(0, binarySearch.GetResult());

            binarySearch.Step(2);
            Assert.AreEqual(1, binarySearch.Right);
            Assert.AreEqual(1, binarySearch.Left);
            Assert.AreEqual(1, binarySearch.GetResult());
        }

        [Test]
        public static void TestStepAndResult5()
        {
            var binarySearch = new BinarySearch(new[] {1,2,3,4,5,6});
            binarySearch.Step(7);
            Assert.AreEqual(5, binarySearch.Right);
            Assert.AreEqual(3, binarySearch.Left);
            Assert.AreEqual(0, binarySearch.GetResult());

            binarySearch.Step(7);
            Assert.AreEqual(5, binarySearch.Right);
            Assert.AreEqual(5, binarySearch.Left);
            Assert.AreEqual(0, binarySearch.GetResult());

            binarySearch.Step(7);
            Assert.AreEqual(5, binarySearch.Right);
            Assert.AreEqual(5, binarySearch.Left);
            Assert.AreEqual(-1, binarySearch.GetResult());
        }

        [Test]
        public static void TestStepAndResult6()
        {
            var binarySearch = new BinarySearch(new[] {1,2,3,4,5,6});
            binarySearch.Step(0);
            Assert.AreEqual(1, binarySearch.Right);
            Assert.AreEqual(0, binarySearch.Left);
            Assert.AreEqual(0, binarySearch.GetResult());

            binarySearch.Step(0);
            Assert.AreEqual(0, binarySearch.Right);
            Assert.AreEqual(0, binarySearch.Left);
            Assert.AreEqual(0, binarySearch.GetResult());

            binarySearch.Step(0);
            Assert.AreEqual(0, binarySearch.Right);
            Assert.AreEqual(0, binarySearch.Left);
            Assert.AreEqual(-1, binarySearch.GetResult());
        }

        [Test]
        public static void TestStepAndResult7()
        {
            var binarySearch = new BinarySearch(new[] {1,2,3,4,5,6,7});
            binarySearch.Step(8);
            Assert.AreEqual(6, binarySearch.Right);
            Assert.AreEqual(4, binarySearch.Left);
            Assert.AreEqual(0, binarySearch.GetResult());

            binarySearch.Step(8);
            Assert.AreEqual(6, binarySearch.Right);
            Assert.AreEqual(6, binarySearch.Left);
            Assert.AreEqual(0, binarySearch.GetResult());

            binarySearch.Step(8);
            Assert.AreEqual(6, binarySearch.Right);
            Assert.AreEqual(6, binarySearch.Left);
            Assert.AreEqual(-1, binarySearch.GetResult());
        }
    }
}