using System.Collections.Generic;
using NUnit.Framework;
using SortSpace;

namespace Tests
{
    class TestsKSort
    {
        [Test]
        public static void TestIndex()
        {
            var result = new KSort();
            var i = result.index("a00");
            Assert.AreEqual(0, i);

            i = result.index("a01");
            Assert.AreEqual(1, i);

            i = result.index("b64");
            Assert.AreEqual(164, i);

            i = result.index("g99");
            Assert.AreEqual(699, i);

            i = result.index("h99");
            Assert.AreEqual(799, i);
        }

        [Test]
        public static void TestAdd()
        {
            var array = new string[] {"a00", "a01", "b64", "g99", "h99"};
            var result = new KSort(array);

            Assert.IsFalse(result.add("sdfsdf"));
            Assert.IsFalse(result.add("w23"));
            Assert.IsFalse(result.add("a123"));
            var value = "A02";
            var i = result.index(value);
            Assert.IsTrue(result.add(value));
            Assert.AreEqual(2, i);
            Assert.AreEqual("A02", result.items[i]);
        }
    }
}