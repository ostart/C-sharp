using System.Collections.Generic;
using NUnit.Framework;
using GallopingSearchSpace;
using System.Linq;

namespace Tests
{
    class TestsGallopingSearch
    {
        [Test]
        public static void TestSearch()
        {
            var result = new GallopingSearch(Enumerable.Range(0, 99).ToArray(), 9);
            Assert.IsTrue(result.Search());
            result = new GallopingSearch(Enumerable.Range(0, 99).ToArray(), 0);
            Assert.IsTrue(result.Search());
            result = new GallopingSearch(Enumerable.Range(0, 99).ToArray(), 3);
            Assert.IsTrue(result.Search());
            result = new GallopingSearch(Enumerable.Range(0, 99).ToArray(), 7);
            Assert.IsTrue(result.Search());
            result = new GallopingSearch(Enumerable.Range(0, 99).ToArray(), 100);
            Assert.IsFalse(result.Search());
            result = new GallopingSearch(Enumerable.Range(1, 100).ToArray(), 0);
            Assert.IsFalse(result.Search());
        }
    }
}