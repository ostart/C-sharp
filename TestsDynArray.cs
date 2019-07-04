using System;
using NUnit.Framework;
using AlgorithmsDataStructures;

namespace Tests
{
    public class TestsDynArray
    {
        [Test]
        public static void InsertInMiddle()
        {
            var testArray = new DynArray<int>();
            for (var i = 1; i <= 5; i++)
            {
                if (i == 3) continue;
                testArray.Append(i);
            }

            Assert.AreEqual(4, testArray.count, "Test InsertInMiddle: Initial array are malformed. Count don't equal 4");
            Assert.AreEqual(16, testArray.capacity, "Test InsertInMiddle: Initial array are malformed. Capacity don't equal 16");

            testArray.Insert(3, 2);

            Assert.AreEqual(5, testArray.count, "Test InsertInMiddle: Array are malformed. Count don't equal 5");
            Assert.AreEqual(16, testArray.capacity, "Test InsertInMiddle: Array are malformed. Capacity don't equal 16");

            for (var i = 0; i < testArray.count; i++)
            {
                Assert.AreEqual(i+1, testArray.GetItem(i), "InsertInMiddle: Problem during enumeration of result array: sequence is corrupted");
            }
        }

        [Test]
        public static void InsertInHead()
        {
            var testArray = new DynArray<int>();
            for (var i = 1; i <= 4; i++)
                testArray.Append(i);

            Assert.AreEqual(4, testArray.count, "Test InsertInHead: Initial array are malformed. Count don't equal 4");
            Assert.AreEqual(16, testArray.capacity, "Test InsertInHead: Initial array are malformed. Capacity don't equal 16");

            testArray.Insert(0, 0);

            Assert.AreEqual(5, testArray.count, "Test InsertInHead: Array are malformed. Count don't equal 5");
            Assert.AreEqual(16, testArray.capacity, "Test InsertInHead: Array are malformed. Capacity don't equal 16");

            for (var i = 0; i < testArray.count; i++)
            {
                Assert.AreEqual(i, testArray.GetItem(i), "InsertInHead: Problem during enumeration of result array: sequence is corrupted");
            }
        }

        [Test]
        public static void InsertInTail()
        {
            var testArray = new DynArray<int>();
            for (var i = 1; i <= 4; i++)
                testArray.Append(i);

            Assert.AreEqual(4, testArray.count, "Test InsertInTail: Initial array are malformed. Count don't equal 4");
            Assert.AreEqual(16, testArray.capacity, "Test InsertInTail: Initial array are malformed. Capacity don't equal 16");

            testArray.Insert(5, 4);

            Assert.AreEqual(5, testArray.count, "Test InsertInTail: Array are malformed. Count don't equal 5");
            Assert.AreEqual(16, testArray.capacity, "Test InsertInTail: Array are malformed. Capacity don't equal 16");

            for (var i = 0; i < testArray.count; i++)
            {
                Assert.AreEqual(i+1, testArray.GetItem(i), "InsertInTail: Problem during enumeration of result array: sequence is corrupted");
            }
        }

        [Test]
        public static void InsertInMiddleCapacityChanged()
        {
            var testArray = new DynArray<int>();
            for (var i = 1; i <= 17; i++)
            {
                if (i == 10) continue;
                testArray.Append(i);
            }

            Assert.AreEqual(16, testArray.count, "Test InsertInMiddleCapacityChanged: Initial array are malformed. Count don't equal 4");
            Assert.AreEqual(16, testArray.capacity, "Test InsertInMiddleCapacityChanged: Initial array are malformed. Capacity don't equal 16");

            testArray.Insert(10, 9);

            Assert.AreEqual(17, testArray.count, "Test InsertInMiddleCapacityChanged: Array are malformed. Count don't equal 17");
            Assert.AreEqual(32, testArray.capacity, "Test InsertInMiddleCapacityChanged: Array are malformed. Capacity don't equal 32");

            for (var i = 0; i < testArray.count; i++)
            {
                Assert.AreEqual(i + 1, testArray.GetItem(i), "InsertInMiddleCapacityChanged: Problem during enumeration of result array: sequence is corrupted");
            }
        }

        [Test]
        public static void InsertException()
        {
            var testArray = new DynArray<int>();
            for (var i = 1; i <= 5; i++)
                testArray.Append(i);

            Assert.AreEqual(5, testArray.count, "Test InsertException: Initial array are malformed. Count don't equal 5");
            Assert.AreEqual(16, testArray.capacity, "Test InsertException: Initial array are malformed. Capacity don't equal 16");

            Assert.Throws<ArgumentOutOfRangeException>(() => testArray.Insert(0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => testArray.Insert(0, 6));
        }

        [Test]
        public static void RemoveFromMiddle()
        {
            var testArray = new DynArray<int>();
            for (var i = 1; i <= 5; i++)
            {
                if (i == 3) testArray.Append(0);
                testArray.Append(i);
            }   

            Assert.AreEqual(6, testArray.count, "Test RemoveFromMiddle: Initial array are malformed. Count don't equal 6");
            Assert.AreEqual(16, testArray.capacity, "Test RemoveFromMiddle: Initial array are malformed. Capacity don't equal 16");

            testArray.Remove(2);

            Assert.AreEqual(5, testArray.count, "Test RemoveFromMiddle: Array are malformed. Count don't equal 5");
            Assert.AreEqual(16, testArray.capacity, "Test RemoveFromMiddle: Array are malformed. Capacity don't equal 16");

            for (var i = 0; i < testArray.count; i++)
            {
                Assert.AreEqual(i + 1, testArray.GetItem(i), "RemoveFromMiddle: Problem during enumeration of result array: sequence is corrupted");
            }
        }

        [Test]
        public static void RemoveFromHead()
        {
            var testArray = new DynArray<int>();
            for (var i = 1; i <= 5; i++)
                testArray.Append(i);

            Assert.AreEqual(5, testArray.count, "Test RemoveFromHead: Initial array are malformed. Count don't equal 5");
            Assert.AreEqual(16, testArray.capacity, "Test RemoveFromHead: Initial array are malformed. Capacity don't equal 16");

            testArray.Remove(0);

            Assert.AreEqual(4, testArray.count, "Test RemoveFromHead: Array are malformed. Count don't equal 4");
            Assert.AreEqual(16, testArray.capacity, "Test RemoveFromHead: Array are malformed. Capacity don't equal 16");

            for (var i = 0; i < testArray.count; i++)
            {
                Assert.AreEqual(i + 2, testArray.GetItem(i), "RemoveFromHead: Problem during enumeration of result array: sequence is corrupted");
            }
        }

        [Test]
        public static void RemoveFromTail()
        {
            var testArray = new DynArray<int>();
            for (var i = 1; i <= 5; i++)
                testArray.Append(i);

            Assert.AreEqual(5, testArray.count, "Test RemoveFromTail: Initial array are malformed. Count don't equal 5");
            Assert.AreEqual(16, testArray.capacity, "Test RemoveFromTail: Initial array are malformed. Capacity don't equal 16");

            testArray.Remove(4);

            Assert.AreEqual(4, testArray.count, "Test RemoveFromTail: Array are malformed. Count don't equal 4");
            Assert.AreEqual(16, testArray.capacity, "Test RemoveFromTail: Array are malformed. Capacity don't equal 16");

            for (var i = 0; i < testArray.count; i++)
            {
                Assert.AreEqual(i + 1, testArray.GetItem(i), "RemoveFromTail: Problem during enumeration of result array: sequence is corrupted");
            }
        }

        [Test]
        public static void RemoveFromMiddleCapacityChanged()
        {
            var testArray = new DynArray<int>();
            for (var i = 1; i <= 16; i++)
            {
                if (i == 10) testArray.Append(0);
                testArray.Append(i);
            }

            Assert.AreEqual(17, testArray.count, "Test RemoveFromMiddleCapacityChanged: Initial array are malformed. Count don't equal 17");
            Assert.AreEqual(32, testArray.capacity, "Test RemoveFromMiddleCapacityChanged: Initial array are malformed. Capacity don't equal 32");

            testArray.Remove(16);

            Assert.AreEqual(16, testArray.count, "Test RemoveFromMiddleCapacityChanged: Array are malformed. Count don't equal 16");
            Assert.AreEqual(32, testArray.capacity, "Test RemoveFromMiddleCapacityChanged: Array are malformed. Capacity don't equal 32");

            testArray.Remove(9);

            Assert.AreEqual(15, testArray.count, "Test RemoveFromMiddleCapacityChanged: Array are malformed. Count don't equal 15");
            Assert.AreEqual(21, testArray.capacity, "Test RemoveFromMiddleCapacityChanged: Array are malformed. Capacity don't equal 21");

            for (var i = 0; i < testArray.count; i++)
            {
                Assert.AreEqual(i + 1, testArray.GetItem(i), "RemoveFromMiddleCapacityChanged: Problem during enumeration of result array: sequence is corrupted");
            }
        }

        [Test]
        public static void RemoveException()
        {
            var testArray = new DynArray<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => testArray.Remove(0));
            
            for (var i = 1; i <= 5; i++)
                testArray.Append(i);

            Assert.AreEqual(5, testArray.count, "Test InsertException: Initial array are malformed. Count don't equal 5");
            Assert.AreEqual(16, testArray.capacity, "Test InsertException: Initial array are malformed. Capacity don't equal 16");

            Assert.Throws<ArgumentOutOfRangeException>(() => testArray.Remove(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => testArray.Remove(6));
        }
    }
}
