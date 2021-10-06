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
            var i = result.GetIndexAndMakeReplace("a00");
            Assert.AreEqual(0, i);

            i = result.GetIndexAndMakeReplace("a01");
            Assert.AreEqual(1, i);

            i = result.GetIndexAndMakeReplace("b64");
            Assert.AreEqual(164, i);

            i = result.GetIndexAndMakeReplace("g99");
            Assert.AreEqual(699, i);

            i = result.GetIndexAndMakeReplace("h99");
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
            var i = result.GetIndexAndMakeReplace(value);
            Assert.IsTrue(result.add(value));
            Assert.AreEqual(2, i);
            Assert.AreEqual("A02", result.Items[i]);
        }
    }
}