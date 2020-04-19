using NUnit.Framework;
using AlgorithmsDataStructures5;
using System;

namespace Tests
{
    public class TestsDynamicMaxQueueStack
    {
        [Test]
        public static void TestDynamicMaxStack()
        {
            var stack = new DynamicMaxStack();
            stack.Push(1);
            Assert.AreEqual(stack.GetMax(), 1);
            stack.Push(2);
            Assert.AreEqual(stack.GetMax(), 2);
            stack.Push(3);
            Assert.AreEqual(stack.GetMax(), 3);
            stack.Push(2);
            Assert.AreEqual(stack.GetMax(), 3);
            stack.Push(1);
            Assert.AreEqual(stack.GetMax(), 3);
            var item = stack.Pop();
            Assert.AreEqual(item, 1);
            Assert.AreEqual(stack.GetMax(), 3);
            item = stack.Pop();
            Assert.AreEqual(item, 2);
            Assert.AreEqual(stack.GetMax(), 3);
            item = stack.Pop();
            Assert.AreEqual(item, 3);
            Assert.AreEqual(stack.GetMax(), 2);
            item = stack.Pop();
            Assert.AreEqual(item, 2);
            Assert.AreEqual(stack.GetMax(), 1);
            item = stack.Pop();
            Assert.AreEqual(item, 1);
            Assert.Throws<InvalidOperationException>(() => stack.GetMax());
        }

        [Test]
        public static void TestDynamicMaxQueue()
        {
            var queue = new DynamicMaxQueue();
            queue.Enqueue(1);
            Assert.AreEqual(queue.GetMax(), 1);
            queue.Enqueue(2);
            Assert.AreEqual(queue.GetMax(), 2);
            queue.Enqueue(3);
            Assert.AreEqual(queue.GetMax(), 3);
            queue.Enqueue(2);
            Assert.AreEqual(queue.GetMax(), 3);
            queue.Enqueue(1);
            Assert.AreEqual(queue.GetMax(), 3);
            queue.Enqueue(4);
            Assert.AreEqual(queue.GetMax(), 4);
            queue.Enqueue(2);
            Assert.AreEqual(queue.GetMax(), 4);
            queue.Enqueue(3);
            Assert.AreEqual(queue.GetMax(), 4);
            queue.Enqueue(4);
            Assert.AreEqual(queue.GetMax(), 4);
            queue.Enqueue(2);
            Assert.AreEqual(queue.GetMax(), 4);
            queue.Enqueue(1);
            Assert.AreEqual(queue.GetMax(), 4);

            var item = queue.Dequeue();
            Assert.AreEqual(item, 1);
            Assert.AreEqual(queue.GetMax(), 4);
            item = queue.Dequeue();
            Assert.AreEqual(item, 2);
            Assert.AreEqual(queue.GetMax(), 4);
            item = queue.Dequeue();
            Assert.AreEqual(item, 3);
            Assert.AreEqual(queue.GetMax(), 4);
            item = queue.Dequeue();
            Assert.AreEqual(item, 2);
            Assert.AreEqual(queue.GetMax(), 4);
            item = queue.Dequeue();
            Assert.AreEqual(item, 1);
            Assert.AreEqual(queue.GetMax(), 4);
            item = queue.Dequeue();
            Assert.AreEqual(item, 4);
            Assert.AreEqual(queue.GetMax(), 4);
            item = queue.Dequeue();
            Assert.AreEqual(item, 2);
            Assert.AreEqual(queue.GetMax(), 4);
            item = queue.Dequeue();
            Assert.AreEqual(item, 3);
            Assert.AreEqual(queue.GetMax(), 4);
            item = queue.Dequeue();
            Assert.AreEqual(item, 4);
            Assert.AreEqual(queue.GetMax(), 2);
            item = queue.Dequeue();
            Assert.AreEqual(item, 2);
            Assert.AreEqual(queue.GetMax(), 1);
            item = queue.Dequeue();
            Assert.AreEqual(item, 1);
            Assert.Throws<NullReferenceException>(() => queue.GetMax());
        }
    }
}