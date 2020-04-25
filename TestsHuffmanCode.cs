using NUnit.Framework;
using AlgorithmsDataStructures5;
using System.Collections.Generic;

namespace Tests
{
    public class TestsHuffmanCode
    {
        [Test]
        public static void TestHuffmanCode()
        {
            Dictionary<char, string> actual = HuffmanCode.Make("мама мыла Раму");
            var expected = new Dictionary<char, string> {
                {'м', "01"},
                {'а', "10"},
                {' ', "110"},
                {'Р', "000"},
                {'у', "001"},
                {'ы', "1110"},
                {'л', "1111"}
            };
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}