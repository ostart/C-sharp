using NUnit.Framework;
using AlgorithmsDataStructures4;
using System.Collections.Generic;

namespace Tests
{
    public class TestsRangeTree
    {
        [Test]
        public static void TestFindValue()
        {
            var init = new List<Point> {
                new Point(5,9),
                new Point(4,2),
                new Point(3,8),
                new Point(1,5),
                new Point(9,4),
                new Point(8,1),
                new Point(7,3),
                new Point(6,7)
            };

            var tree = new RangeTree(init);
           
            var expected = new List<Point> {
                new Point(3,8),
                new Point(6,7),
                new Point(7,3)
            };
            var actual = tree.GetPoints(3,8,3,8);
            Assert.IsTrue(CheckLists(expected, actual));

            var expected2 = new List<Point> {
                new Point(4,2)
            };
            var actual2 = tree.GetPoints(2,5,2,5);
            Assert.IsTrue(CheckLists(expected2, actual2));

            var expected3 = new List<Point>();
            var actual3 = tree.GetPoints(8,9,8,9);
            Assert.IsTrue(CheckLists(expected3, actual3));
        }
        
        private static bool CheckLists(List<Point> expected, List<Point> actual)
        {
            if (expected.Count != actual.Count) return false;

            for (int i = 0; i < expected.Count; i++)
            {
                if (expected[i].X != actual[i].X || expected[i].Y != actual[i].Y)
                    return false;
            }

            return true;
        }

    }
}