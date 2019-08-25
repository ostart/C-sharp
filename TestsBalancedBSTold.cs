using NUnit.Framework;
using AlgorithmsDataStructures2;

namespace Tests
{
    class TestsBalancedBSTold
    {
        [Test]
        public void TestGenerateBBSTArray()
        {
            var arr = new int[] {10, 12, 8, 14, 7, 6, 15, 13, 11, 1, 9, 2, 3, 4, 5};
            var result = BalancedBSTold.GenerateBBSTArray(arr);
            var ethalon = new int[] {8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15};
            Assert.AreEqual(ethalon.Length, result.Length);
            for(var i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(ethalon[i], result[i]);
            }
        }
    }
}