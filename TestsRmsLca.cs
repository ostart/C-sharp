using NUnit.Framework;
using AlgorithmsDataStructures4;

namespace Tests
{
    public class TestsRmsLca
    {
        [Test]
        public static void TestTreeTopDown()
        {
            var arr = new int[] {3,5,7,0,2,1,8,6,4};
            var tree = new RmqLca(arr, GetMinValue);
            tree.FormTreeTopDown();
            Assert.AreEqual(0, tree.FindFuncValue(0, 8));
            Assert.AreEqual(1, tree.FindFuncValue(5, 8));
            Assert.AreEqual(3, tree.FindFuncValue(0, 2));
            Assert.AreEqual(0, tree.FindFuncValue(2, 5));
            Assert.AreEqual(1, tree.FindFuncValue(4, 5));
            Assert.AreEqual(3, tree.FindFuncValue(0, 0));
            Assert.AreEqual(8, tree.FindFuncValue(6, 6));
        }

        [Test]
        public static void TestTreeUpward()
        {
            var arr = new int[] {3,5,7,0,2,1,8,6,4};
            var tree = new RmqLca(arr, GetMinValue);
            tree.FormTreeUpward();
            Assert.AreEqual(0, tree.FindFuncValue(0, 8));
            Assert.AreEqual(1, tree.FindFuncValue(5, 8));
            Assert.AreEqual(3, tree.FindFuncValue(0, 2));
            Assert.AreEqual(0, tree.FindFuncValue(2, 5));
            Assert.AreEqual(1, tree.FindFuncValue(4, 5));
            Assert.AreEqual(3, tree.FindFuncValue(0, 0));
            Assert.AreEqual(8, tree.FindFuncValue(6, 6));
        }

        public static int GetMinValue(int[] arr, int start, int stop)
        {
            var result = arr[start];
            for (int i = start; i <= stop; i++)
            {
                if(arr[i] < result)
                    result = arr[i];
            }
            return result;
        }
    }
}
