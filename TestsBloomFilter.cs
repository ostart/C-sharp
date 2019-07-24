using NUnit.Framework;
using AlgorithmsDataStructures;

namespace Tests
{
    public class TestsBloomFilter
    {
        static string zero = "0123456789";
        static string one = "1234567890";
        static string two = "2345678901";
        static string three = "3456789012";
        static string four = "4567890123";
        static string five = "5678901234";
        static string six = "6789012345";
        static string seven = "7890123456";
        static string eigth = "8901234567";
        static string nine = "9012345678";

        [Test]
        public static void TestsHash1()
        {
            var testFilter = new BloomFilter(32);
            Assert.AreEqual(32, testFilter.bitArray.Length);       
            Assert.AreEqual(32, testFilter.filter_len);       
            Assert.AreEqual(13, testFilter.Hash1(zero));
            foreach(bool item in testFilter.bitArray)
                Assert.IsTrue(item == false);
        }

        [Test]
        public static void TestsHash2()
        {
            var testFilter = new BloomFilter(32);
            Assert.AreEqual(32, testFilter.bitArray.Length);       
            Assert.AreEqual(32, testFilter.filter_len);   
            Assert.AreEqual(5, testFilter.Hash2(zero));
            foreach(bool item in testFilter.bitArray)
                Assert.IsTrue(item == false);
        }

        [Test]
        public static void TestsAdd02468()
        {
            var testFilter = new BloomFilter(32);
            Assert.AreEqual(32, testFilter.bitArray.Length);       
            Assert.AreEqual(32, testFilter.filter_len);   
            testFilter.Add(zero);
            testFilter.Add(two);
            testFilter.Add(four);
            testFilter.Add(six);
            testFilter.Add(eigth);
            for(int i = 0; i<testFilter.filter_len; i++)
            {
                if (i == 5 || i == 13) Assert.IsTrue(testFilter.bitArray[i] == true);
                else Assert.IsTrue(testFilter.bitArray[i] == false);
            }
        }

        [Test]
        public static void TestsAdd13579()
        {
            var testFilter = new BloomFilter(32);
            Assert.AreEqual(32, testFilter.bitArray.Length);       
            Assert.AreEqual(32, testFilter.filter_len);   
            testFilter.Add(one);
            testFilter.Add(three);
            testFilter.Add(five);
            testFilter.Add(seven);
            testFilter.Add(nine);
            for(int i = 0; i<testFilter.filter_len; i++)
            {
                if (i == 27 || i == 29) Assert.IsTrue(testFilter.bitArray[i] == true);
                else Assert.IsTrue(testFilter.bitArray[i] == false);
            }
        }

        
        [Test]
        public static void TestsIsValue()
        {
            var testFilter = new BloomFilter(32);
            Assert.AreEqual(32, testFilter.bitArray.Length);       
            Assert.AreEqual(32, testFilter.filter_len);   
            testFilter.Add(zero);
            testFilter.Add(one);
            for(int i = 0; i<testFilter.filter_len; i++)
            {
                if (i == 5 || i == 13 || i == 27 || i == 29) Assert.IsTrue(testFilter.bitArray[i] == true);
                else Assert.IsTrue(testFilter.bitArray[i] == false);
            }
            Assert.IsTrue(testFilter.IsValue(zero));
            Assert.IsTrue(testFilter.IsValue(one));
            Assert.IsTrue(testFilter.IsValue(two));
            Assert.IsTrue(testFilter.IsValue(three));
            Assert.IsTrue(testFilter.IsValue(four));
            Assert.IsTrue(testFilter.IsValue(five));
            Assert.IsTrue(testFilter.IsValue(six));
            Assert.IsTrue(testFilter.IsValue(seven));
            Assert.IsTrue(testFilter.IsValue(eigth));
            Assert.IsTrue(testFilter.IsValue(nine));
        }

        
    }
}