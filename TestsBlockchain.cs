using NUnit.Framework;
using AlgorithmsDataStructures6;
using System.Diagnostics;

namespace Tests
{
    public class TestsBlockchain
    {
        [Test]
        public void Test1Zero()
        {
            var watch = Stopwatch.StartNew();
            var blockchain = new Blockchain(1);
            blockchain.AddBlock("One");
            blockchain.AddBlock("Two");
            blockchain.AddBlock("Three");
            blockchain.AddBlock("Four");
            blockchain.AddBlock("Five");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Debug.WriteLine("1 zero: " + elapsedMs);
            Assert.AreEqual(6, blockchain.Blocks.Count);
            Assert.IsTrue(blockchain.IsCorrectChain());
        }

        [Test]
        public void Test2Zero()
        {
            var watch = Stopwatch.StartNew();
            var blockchain = new Blockchain(2);
            blockchain.AddBlock("One");
            blockchain.AddBlock("Two");
            blockchain.AddBlock("Three");
            blockchain.AddBlock("Four");
            blockchain.AddBlock("Five");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Debug.WriteLine("2 zero: " + elapsedMs);
            Assert.AreEqual(6, blockchain.Blocks.Count);
            Assert.IsTrue(blockchain.IsCorrectChain());
        }

        [Test]
        public void Test3Zero()
        {
            var watch = Stopwatch.StartNew();
            var blockchain = new Blockchain(3);
            blockchain.AddBlock("One");
            blockchain.AddBlock("Two");
            blockchain.AddBlock("Three");
            blockchain.AddBlock("Four");
            blockchain.AddBlock("Five");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Debug.WriteLine("3 zero: " + elapsedMs);
            Assert.AreEqual(6, blockchain.Blocks.Count);
            Assert.IsTrue(blockchain.IsCorrectChain());
        }

        [Test]
        public void Test4Zero()
        {
            var watch = Stopwatch.StartNew();
            var blockchain = new Blockchain(4);
            blockchain.AddBlock("One");
            blockchain.AddBlock("Two");
            blockchain.AddBlock("Three");
            blockchain.AddBlock("Four");
            blockchain.AddBlock("Five");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Debug.WriteLine("4 zero: " + elapsedMs);
            Assert.AreEqual(6, blockchain.Blocks.Count);
            Assert.IsTrue(blockchain.IsCorrectChain());
        }

        [Test]
        public void Test5Zero()
        {
            var watch = Stopwatch.StartNew();
            var blockchain = new Blockchain(5);
            blockchain.AddBlock("One");
            blockchain.AddBlock("Two");
            blockchain.AddBlock("Three");
            blockchain.AddBlock("Four");
            blockchain.AddBlock("Five");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Debug.WriteLine("5 zero: " + elapsedMs);
            Assert.AreEqual(6, blockchain.Blocks.Count);
            Assert.IsTrue(blockchain.IsCorrectChain());
        }
    }
}