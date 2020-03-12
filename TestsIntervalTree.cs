using NUnit.Framework;
using AlgorithmsDataStructures4;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Tests
{
    public class TestsIntervalTree
    {
        [Test]
        public static void TestFindValue()
        {
            var init = new List<Interval> {
                new Interval(-10, -5),
                new Interval(-8, -4),
                new Interval(-7, 4),
                new Interval(-5, 1),
                new Interval(0, 5),
                new Interval(-2, 5),
                new Interval(0, 8),
                new Interval(4, 9),
                new Interval(5, 10),
                new Interval(-9, 9)                
            };

            var tree = new IntervalTree(init);

            var expected = new List<Interval> {
                new Interval(-7, 4),
                new Interval(-5, 1),
                new Interval(0, 5),
                new Interval(-2, 5),
                new Interval(0, 8),
                new Interval(-9, 9)
            };
            var actual = tree.GetIntervals(0);
            Assert.IsTrue(CheckLists(expected, actual));

            var expected2 = new List<Interval> {
                new Interval(0, 8),
                new Interval(-9, 9),
                new Interval(4, 9),
                new Interval(5, 10)                
            };
            var actual2 = tree.GetIntervals(6);
            Assert.IsTrue(CheckLists(expected2, actual2));

            var expected3 = new List<Interval> {
                new Interval(-9, 9),
                new Interval(4, 9),
                new Interval(5, 10)                
            };
            var actual3 = tree.GetIntervals(9);
            Assert.IsTrue(CheckLists(expected3, actual3));

            var expected4 = new List<Interval> {
                new Interval(-10, -5)              
            };
            var actual4 = tree.GetIntervals(-10);
            Assert.IsTrue(CheckLists(expected4, actual4));
        }

        private static bool CheckLists(List<Interval> expected, List<Interval> actual)
        {
            if (expected.Count != actual.Count) return false;

            for (int i = 0; i < expected.Count; i++)
            {
                if (expected[i].Bottom != actual[i].Bottom || expected[i].Top != actual[i].Top)
                    return false;
            }

            return true;
        }
    }
}