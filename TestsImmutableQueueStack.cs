using NUnit.Framework;
using AlgorithmsDataStructures5;

namespace Tests
{
    public class TestsDynamicQueueStack
    {
        [Test]
        public static void TestImmutableQueue()
        {
            var queue = new ImmutableQueue<int>();
            queue = queue.Enqueue(1);
            Assert.AreEqual(queue.Size(), 1);
            var queue2 = queue.Enqueue(2).Enqueue(3);
            Assert.AreEqual(queue.Size(), 1);
            Assert.AreEqual(queue2.Size(), 3);
            var queue3 = queue2.Dequeue(out var result);
            Assert.AreEqual(queue.Size(), 1);
            Assert.AreEqual(queue2.Size(), 3);
            Assert.AreEqual(queue3.Size(), 2);
            Assert.AreEqual(result, 1);
            var queue4 = queue3.Dequeue(out var result2);
            Assert.AreEqual(queue.Size(), 1);
            Assert.AreEqual(queue2.Size(), 3);
            Assert.AreEqual(queue3.Size(), 2);
            Assert.AreEqual(queue4.Size(), 1);
            Assert.AreEqual(result2, 2);
        }

        [Test]
        public static void TestImmutableStack()
        {
            var stack = new ImmutableStack<int>();
            stack = stack.Push(1);
            Assert.AreEqual(stack.Size(), 1);
            var stack2 = stack.Push(2).Push(3);
            Assert.AreEqual(stack.Size(), 1);
            Assert.AreEqual(stack2.Size(), 3);
            var stack3 = stack2.Pop(out var result);
            Assert.AreEqual(stack.Size(), 1);
            Assert.AreEqual(stack2.Size(), 3);
            Assert.AreEqual(stack3.Size(), 2);
            Assert.AreEqual(result, 3);
            var stack4 = stack3.Pop(out var result2);
            Assert.AreEqual(stack.Size(), 1);
            Assert.AreEqual(stack2.Size(), 3);
            Assert.AreEqual(stack3.Size(), 2);
            Assert.AreEqual(stack4.Size(), 1);
            Assert.AreEqual(result2, 2);
        }
    }
}