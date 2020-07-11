using NUnit.Framework;
using AlgorithmsDataStructures6;
using System.Diagnostics;

namespace Tests
{
    public class TestsBlockchain
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        // [TestCase(7)]
        // [TestCase(8)]
        public void TestZeros(int zeros)
        {
            var watch = Stopwatch.StartNew();
            var blockchain = new Blockchain(zeros);
            blockchain.AddBlock("One");
            blockchain.AddBlock("Two");
            blockchain.AddBlock("Three");
            blockchain.AddBlock("Four");
            blockchain.AddBlock("Five");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Debug.WriteLine($"{zeros} zeros: " + elapsedMs);
            Assert.AreEqual(6, blockchain.Blocks.Count);
            Assert.IsTrue(blockchain.IsCorrectChain());
        }
    }
}