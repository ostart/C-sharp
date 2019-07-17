using NUnit.Framework;
using AlgorithmsDataStructures;

namespace Tests
{
    public class TestsNativeDictionary
    {
        [Test]
        public static void TestsNativeDictionaryPut()
        {
            var testDict = new NativeDictionary<int>(3);
            Assert.AreEqual(3, testDict.size);
            testDict.Put("one", 1);
            Assert.AreEqual("one", testDict.slots[1]);
            Assert.AreEqual(1, testDict.values[1]);
            testDict.Put("three", 3);
            Assert.AreEqual("three", testDict.slots[2]);
            Assert.AreEqual(3, testDict.values[2]);
            testDict.Put("one", 2);
            Assert.AreEqual("one", testDict.slots[1]);
            Assert.AreEqual(2, testDict.values[1]);
        }

        [Test]
        public static void TestsNativeDictionaryIsKey()
        {
            var testDict = new NativeDictionary<int>(3);
            Assert.AreEqual(3, testDict.size);
            testDict.Put("one", 1);
            Assert.AreEqual("one", testDict.slots[1]);
            Assert.AreEqual(1, testDict.values[1]);

            Assert.IsTrue(testDict.IsKey("one"));
            Assert.IsFalse(testDict.IsKey("two"));
        }

        [Test]
        public static void TestsNativeDictionaryGet()
        {
            var testDict = new NativeDictionary<int>(3);
            Assert.AreEqual(3, testDict.size);
            testDict.Put("one", 1);
            Assert.AreEqual("one", testDict.slots[1]);
            Assert.AreEqual(1, testDict.values[1]);

            Assert.AreEqual(1, testDict.Get("one"));
            Assert.AreEqual(default(int), testDict.Get("two"));
        }
    }
}
