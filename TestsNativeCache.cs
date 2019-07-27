using NUnit.Framework;
using AlgorithmsDataStructures;

namespace Tests
{
    public class TestsNativeCache
    {
        [Test]
        public void TestsNativeCachePutAndGet()
        {
            var cache = new NativeCache<string>(3);
            Assert.AreEqual(3, cache.size);
            foreach (var slot in cache.slots)
                Assert.IsNull(slot);
            foreach (var hit in cache.hits)
                Assert.AreEqual(0, hit);

            cache.Put("1", "one");
            foreach (var hit in cache.hits)
                Assert.AreEqual(0, hit);
            for (int i = 0; i < cache.size; i++)
            {
                if (i == 1)
                {
                    Assert.AreEqual("1", cache.slots[1]);
                    Assert.AreEqual("one", cache.values[1]);
                }
                else
                {
                    Assert.AreEqual(null, cache.slots[i]);
                    Assert.AreEqual(null, cache.values[i]);
                }
            }
            cache.Put("2", "two");
            foreach (var hit in cache.hits)
                Assert.AreEqual(0, hit);
            for (int i = 0; i < cache.size; i++)
            {
                if (i == 1)
                {
                    Assert.AreEqual("1", cache.slots[1]);
                    Assert.AreEqual("one", cache.values[1]);
                }
                else if (i == 2)
                {
                    Assert.AreEqual("2", cache.slots[2]);
                    Assert.AreEqual("two", cache.values[2]);
                }
                else
                {
                    Assert.IsNull(cache.slots[i]);
                    Assert.IsNull(cache.values[i]);
                }
            }
            cache.Put("3", "three");
            foreach (var hit in cache.hits)
                Assert.AreEqual(0, hit);
            for (int i = 0; i < cache.size; i++)
            {
                if (i == 0)
                {
                    Assert.AreEqual("3", cache.slots[0]);
                    Assert.AreEqual("three", cache.values[0]);
                }
                else if (i == 1)
                {
                    Assert.AreEqual("1", cache.slots[1]);
                    Assert.AreEqual("one", cache.values[1]);
                }
                else if (i == 2)
                {
                    Assert.AreEqual("2", cache.slots[2]);
                    Assert.AreEqual("two", cache.values[2]);
                }
                else
                {
                    Assert.IsNull(cache.slots[i]);
                    Assert.IsNull(cache.values[i]);
                }
            }

            var one = cache.Get("1");
            Assert.AreEqual("one", one);
            var two = cache.Get("2");
            Assert.AreEqual("two", two);
            var three = cache.Get("3");
            Assert.AreEqual("three", three);
            foreach (var hit in cache.hits)
            {
                Assert.AreEqual(1, hit);
            }
            two = cache.Get("2");
            Assert.AreEqual("two", two);
            three = cache.Get("3");
            Assert.AreEqual("three", three);
            three = cache.Get("3");
            Assert.AreEqual("three", three);

            Assert.AreEqual(3, cache.hits[0]);
            Assert.AreEqual(1, cache.hits[1]);
            Assert.AreEqual(2, cache.hits[2]);

            cache.Put("5", "five");
            Assert.AreEqual(2, cache.HashFun("5"));
            for (int i = 0; i < cache.size; i++)
            {
                if (i == 0)
                {
                    Assert.AreEqual("3", cache.slots[0]);
                    Assert.AreEqual("three", cache.values[0]);
                }
                else if (i == 1)
                {
                    Assert.AreEqual("5", cache.slots[1]);
                    Assert.AreEqual("five", cache.values[1]);
                }
                else if (i == 2)
                {
                    Assert.AreEqual("2", cache.slots[2]);
                    Assert.AreEqual("two", cache.values[2]);
                }
                else
                {
                    Assert.IsNull(cache.slots[i]);
                    Assert.IsNull(cache.values[i]);
                }
            }

            Assert.AreEqual(3, cache.hits[0]);
            Assert.AreEqual(0, cache.hits[1]);
            Assert.AreEqual(2, cache.hits[2]);

            cache.Put("6", "six");
            Assert.AreEqual(0, cache.HashFun("6"));
            for (int i = 0; i < cache.size; i++)
            {
                if (i == 0)
                {
                    Assert.AreEqual("3", cache.slots[0]);
                    Assert.AreEqual("three", cache.values[0]);
                }
                else if (i == 1)
                {
                    Assert.AreEqual("6", cache.slots[1]);
                    Assert.AreEqual("six", cache.values[1]);
                }
                else if (i == 2)
                {
                    Assert.AreEqual("2", cache.slots[2]);
                    Assert.AreEqual("two", cache.values[2]);
                }
                else
                {
                    Assert.IsNull(cache.slots[i]);
                    Assert.IsNull(cache.values[i]);
                }
            }

            Assert.AreEqual(3, cache.hits[0]);
            Assert.AreEqual(0, cache.hits[1]);
            Assert.AreEqual(2, cache.hits[2]);
        }
    }
}
