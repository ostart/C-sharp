using NUnit.Framework;
using AlgorithmsDataStructures;

namespace Tests
{
    public class TestsPowerSet
    {
        [Test]
        public static void TestsPowerSetPut()
        {
            var testPowerSet = new PowerSet<int>();
            Assert.AreEqual(0, testPowerSet.Size());
            testPowerSet.Put(1);
            Assert.AreEqual(1, testPowerSet.Size());
            Assert.IsTrue(testPowerSet.Get(1));
            testPowerSet.Put(2);
            Assert.AreEqual(2, testPowerSet.Size());
            Assert.IsTrue(testPowerSet.Get(1));
            Assert.IsTrue(testPowerSet.Get(2));
            testPowerSet.Put(1);
            Assert.AreEqual(2, testPowerSet.Size());
            Assert.IsTrue(testPowerSet.Get(1));
            Assert.IsTrue(testPowerSet.Get(2));
        }

        [Test]
        public static void TestsPowerSetRemove()
        {
            var testPowerSet = new PowerSet<int>();
            Assert.AreEqual(0, testPowerSet.Size());
            testPowerSet.Put(1);
            Assert.AreEqual(1, testPowerSet.Size());
            Assert.IsTrue(testPowerSet.Get(1));
            testPowerSet.Put(2);
            Assert.AreEqual(2, testPowerSet.Size());
            Assert.IsTrue(testPowerSet.Get(1));
            Assert.IsTrue(testPowerSet.Get(2));
            testPowerSet.Remove(1);
            Assert.AreEqual(1, testPowerSet.Size());
            Assert.IsFalse(testPowerSet.Get(1));
            Assert.IsTrue(testPowerSet.Get(2));
            testPowerSet.Remove(2);
            Assert.AreEqual(0, testPowerSet.Size());
            Assert.IsFalse(testPowerSet.Get(1));
            Assert.IsFalse(testPowerSet.Get(2));
        }

        [Test]
        public static void TestsPowerSetIntersection()
        {
            var testPowerSet1 = new PowerSet<int>();
            var testPowerSet2 = new PowerSet<int>();
            Assert.AreEqual(0, testPowerSet1.Size());
            Assert.AreEqual(0, testPowerSet2.Size());

            testPowerSet1.Put(1);
            Assert.AreEqual(1, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            testPowerSet1.Put(2);
            Assert.AreEqual(2, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            Assert.IsTrue(testPowerSet1.Get(2));
            testPowerSet1.Put(3);
            Assert.AreEqual(3, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            Assert.IsTrue(testPowerSet1.Get(2));
            Assert.IsTrue(testPowerSet1.Get(3));

            testPowerSet2.Put(2);
            Assert.AreEqual(1, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(2));
            testPowerSet2.Put(3);
            Assert.AreEqual(2, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(2));
            Assert.IsTrue(testPowerSet2.Get(3));
            testPowerSet2.Put(4);
            Assert.AreEqual(3, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(4));
            Assert.IsTrue(testPowerSet2.Get(2));
            Assert.IsTrue(testPowerSet2.Get(3));

            var result = testPowerSet1.Intersection(testPowerSet2);
            Assert.AreEqual(2, result.Size());
            Assert.IsTrue(result.Get(2));
            Assert.IsTrue(result.Get(3));
        }

        [Test]
        public static void TestsPowerSetIntersectionNull()
        {
            var testPowerSet1 = new PowerSet<int>();
            var testPowerSet2 = new PowerSet<int>();
            Assert.AreEqual(0, testPowerSet1.Size());
            Assert.AreEqual(0, testPowerSet2.Size());

            testPowerSet1.Put(1);
            Assert.AreEqual(1, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            testPowerSet1.Put(2);
            Assert.AreEqual(2, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            Assert.IsTrue(testPowerSet1.Get(2));
            testPowerSet1.Put(3);
            Assert.AreEqual(3, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            Assert.IsTrue(testPowerSet1.Get(2));
            Assert.IsTrue(testPowerSet1.Get(3));

            testPowerSet2.Put(4);
            Assert.AreEqual(1, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(4));
            testPowerSet2.Put(5);
            Assert.AreEqual(2, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(4));
            Assert.IsTrue(testPowerSet2.Get(5));
            testPowerSet2.Put(6);
            Assert.AreEqual(3, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(4));
            Assert.IsTrue(testPowerSet2.Get(5));
            Assert.IsTrue(testPowerSet2.Get(6));

            var result = testPowerSet1.Intersection(testPowerSet2);
            Assert.IsNull(result);
        }

        [Test]
        public static void TestsPowerSetUnion()
        {
            var testPowerSet1 = new PowerSet<int>();
            var testPowerSet2 = new PowerSet<int>();
            Assert.AreEqual(0, testPowerSet1.Size());
            Assert.AreEqual(0, testPowerSet2.Size());

            testPowerSet1.Put(1);
            Assert.AreEqual(1, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            testPowerSet1.Put(2);
            Assert.AreEqual(2, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            Assert.IsTrue(testPowerSet1.Get(2));
            testPowerSet1.Put(3);
            Assert.AreEqual(3, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            Assert.IsTrue(testPowerSet1.Get(2));
            Assert.IsTrue(testPowerSet1.Get(3));

            testPowerSet2.Put(2);
            Assert.AreEqual(1, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(2));
            testPowerSet2.Put(3);
            Assert.AreEqual(2, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(2));
            Assert.IsTrue(testPowerSet2.Get(3));
            testPowerSet2.Put(4);
            Assert.AreEqual(3, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(2));
            Assert.IsTrue(testPowerSet2.Get(3));
            Assert.IsTrue(testPowerSet2.Get(4));

            var result = testPowerSet1.Union(testPowerSet2);
            Assert.AreEqual(4, result.Size());
            Assert.IsTrue(result.Get(1));
            Assert.IsTrue(result.Get(2));
            Assert.IsTrue(result.Get(3));
            Assert.IsTrue(result.Get(4));
        }

        [Test]
        public static void TestsPowerSetUnionEmpty()
        {
            var testPowerSet1 = new PowerSet<int>();
            var testPowerSet2 = new PowerSet<int>();
            Assert.AreEqual(0, testPowerSet1.Size());
            Assert.AreEqual(0, testPowerSet2.Size());

            testPowerSet1.Put(1);
            Assert.AreEqual(1, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            testPowerSet1.Put(2);
            Assert.AreEqual(2, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            Assert.IsTrue(testPowerSet1.Get(2));
            testPowerSet1.Put(3);
            Assert.AreEqual(3, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            Assert.IsTrue(testPowerSet1.Get(2));
            Assert.IsTrue(testPowerSet1.Get(3));

            var result = testPowerSet1.Union(testPowerSet2);
            Assert.AreEqual(3, result.Size());
            Assert.IsTrue(result.Get(1));
            Assert.IsTrue(result.Get(2));
            Assert.IsTrue(result.Get(3));
        }

        [Test]
        public static void TestsPowerSetDifference()
        {
            var testPowerSet1 = new PowerSet<int>();
            var testPowerSet2 = new PowerSet<int>();
            Assert.AreEqual(0, testPowerSet1.Size());
            Assert.AreEqual(0, testPowerSet2.Size());

            testPowerSet1.Put(1);
            Assert.AreEqual(1, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            testPowerSet1.Put(2);
            Assert.AreEqual(2, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            Assert.IsTrue(testPowerSet1.Get(2));
            testPowerSet1.Put(3);
            Assert.AreEqual(3, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            Assert.IsTrue(testPowerSet1.Get(2));
            Assert.IsTrue(testPowerSet1.Get(3));

            testPowerSet2.Put(1);
            Assert.AreEqual(1, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(1));
            testPowerSet2.Put(3);
            Assert.AreEqual(2, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(1));
            Assert.IsTrue(testPowerSet2.Get(3));

            var result = testPowerSet1.Difference(testPowerSet2);
            Assert.AreEqual(1, result.Size());
            Assert.IsTrue(result.Get(2));
        }

        [Test]
        public static void TestsPowerSetDifferenceNull()
        {
            var testPowerSet1 = new PowerSet<int>();
            var testPowerSet2 = new PowerSet<int>();
            Assert.AreEqual(0, testPowerSet1.Size());
            Assert.AreEqual(0, testPowerSet2.Size());

            testPowerSet1.Put(1);
            Assert.AreEqual(1, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            testPowerSet1.Put(2);
            Assert.AreEqual(2, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            Assert.IsTrue(testPowerSet1.Get(2));
            testPowerSet1.Put(3);
            Assert.AreEqual(3, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            Assert.IsTrue(testPowerSet1.Get(2));
            Assert.IsTrue(testPowerSet1.Get(3));

            testPowerSet2.Put(1);
            Assert.AreEqual(1, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(1));
            testPowerSet2.Put(2);
            Assert.AreEqual(2, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(1));
            Assert.IsTrue(testPowerSet2.Get(2));
            testPowerSet2.Put(3);
            Assert.AreEqual(3, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(1));
            Assert.IsTrue(testPowerSet2.Get(2));
            Assert.IsTrue(testPowerSet2.Get(3));

            var result = testPowerSet1.Difference(testPowerSet2);
            Assert.IsNull(result);
        }

        [Test]
        public static void TestsPowerSetIssubset()
        {
            var testPowerSet1 = new PowerSet<int>();
            var testPowerSet2 = new PowerSet<int>();
            Assert.AreEqual(0, testPowerSet1.Size());
            Assert.AreEqual(0, testPowerSet2.Size());

            testPowerSet1.Put(1);
            Assert.AreEqual(1, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            testPowerSet1.Put(2);
            Assert.AreEqual(2, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            Assert.IsTrue(testPowerSet1.Get(2));
            testPowerSet1.Put(3);
            Assert.AreEqual(3, testPowerSet1.Size());
            Assert.IsTrue(testPowerSet1.Get(1));
            Assert.IsTrue(testPowerSet1.Get(2));
            Assert.IsTrue(testPowerSet1.Get(3));

            testPowerSet2.Put(2);
            Assert.AreEqual(1, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(2));
            testPowerSet2.Put(3);
            Assert.AreEqual(2, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(2));
            Assert.IsTrue(testPowerSet2.Get(3));

            Assert.IsTrue(testPowerSet1.IsSubset(testPowerSet2));
            Assert.IsFalse(testPowerSet2.IsSubset(testPowerSet1));

            testPowerSet2.Put(1);
            Assert.AreEqual(3, testPowerSet2.Size());
            Assert.IsTrue(testPowerSet2.Get(2));
            Assert.IsTrue(testPowerSet2.Get(3));
            Assert.IsTrue(testPowerSet2.Get(1));
            Assert.IsTrue(testPowerSet1.IsSubset(testPowerSet2));
            Assert.IsTrue(testPowerSet2.IsSubset(testPowerSet1));
        }
    }
}
