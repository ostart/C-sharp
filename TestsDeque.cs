using System;
using NUnit.Framework;
using AlgorithmsDataStructures;

namespace Tests
{
    public class TestsDeque
    {
        [Test]
        public static void TestAddRemoveFront()
        {
            var deque = new Deque<int>();
            Assert.AreEqual(0, deque.Size(), "TestSize must be 0, but not");
            deque.AddFront(1);
            Assert.AreEqual(1, deque.Size(), "TestSize must be 1, but not");
            deque.AddFront(2);
            deque.AddFront(3);
            Assert.AreEqual(3, deque.Size(), "TestSize must be 3, but not");
            var head = deque.RemoveFront();
            Assert.AreEqual(3, head, "TestAddFront head must be 3, but not");
            Assert.AreEqual(2, deque.Size(), "TestSize must be 2, but not");
            head = deque.RemoveFront();
            Assert.AreEqual(2, head, "TestAddFront head must be 2, but not");
            Assert.AreEqual(1, deque.Size(), "TestSize must be 1, but not");
            head = deque.RemoveFront();
            Assert.AreEqual(1, head, "TestAddFront head must be 1, but not");
            Assert.AreEqual(0, deque.Size(), "TestSize must be 0, but not");
            Assert.Throws<NullReferenceException>(() => deque.RemoveFront());
        }

        [Test]
        public static void TestAddRemoveTail()
        {
            var deque = new Deque<int>();
            Assert.AreEqual(0, deque.Size(), "TestSize must be 0, but not");
            deque.AddTail(1);
            Assert.AreEqual(1, deque.Size(), "TestSize must be 1, but not");
            deque.AddTail(2);
            deque.AddTail(3);
            Assert.AreEqual(3, deque.Size(), "TestSize must be 3, but not");
            var tail = deque.RemoveTail();
            Assert.AreEqual(3, tail, "TestAddFront head must be 3, but not");
            Assert.AreEqual(2, deque.Size(), "TestSize must be 2, but not");
            tail = deque.RemoveTail();
            Assert.AreEqual(2, tail, "TestAddFront head must be 2, but not");
            Assert.AreEqual(1, deque.Size(), "TestSize must be 1, but not");
            tail = deque.RemoveTail();
            Assert.AreEqual(1, tail, "TestAddFront head must be 1, but not");
            Assert.AreEqual(0, deque.Size(), "TestSize must be 0, but not");
            Assert.Throws<NullReferenceException>(() => deque.RemoveTail());
        }

        [Test]
        public static void TestClassicQueue()
        {
            var deque = new Deque<int>();
            Assert.AreEqual(0, deque.Size(), "TestSize must be 0, but not");
            deque.AddTail(1);
            Assert.AreEqual(1, deque.Size(), "TestSize must be 1, but not");
            deque.AddTail(2);
            deque.AddTail(3);
            Assert.AreEqual(3, deque.Size(), "TestSize must be 3, but not");
            var head = deque.RemoveFront();
            Assert.AreEqual(1, head, "TestAddFront head must be 1, but not");
            Assert.AreEqual(2, deque.Size(), "TestSize must be 2, but not");
            head = deque.RemoveFront();
            Assert.AreEqual(2, head, "TestAddFront head must be 2, but not");
            Assert.AreEqual(1, deque.Size(), "TestSize must be 1, but not");
            head = deque.RemoveFront();
            Assert.AreEqual(3, head, "TestAddFront head must be 3, but not");
            Assert.AreEqual(0, deque.Size(), "TestSize must be 0, but not");
        }

        [Test]
        public static void TestPalindrome()
        {
            Assert.IsTrue(DequeExtra.IsPalindrome("rotor"));
            Assert.IsTrue(DequeExtra.IsPalindrome("РОТАТОР"));
            Assert.IsFalse(DequeExtra.IsPalindrome("superman"));
            Assert.IsTrue(DequeExtra.IsPalindrome("ALLA"));
        }
    }
}
