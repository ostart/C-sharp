using NUnit.Framework;
using AlgorithmsDataStructures;

namespace Tests
{
    public class TestsQueue
    {
        [Test]
        public static void TestQueueMethods()
        {
            var queue = new Queue<int>();
            Assert.AreEqual(0, queue.Size(), "TestSize must be 0, but not");
            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Size(), "TestSize must be 1, but not");
            queue.Enqueue(2);
            Assert.AreEqual(2, queue.Size(), "TestSize must be 2, but not");
            queue.Enqueue(3);
            Assert.AreEqual(3, queue.Size(), "TestSize must be 3, but not");
            
            var value = queue.Dequeue();
            Assert.AreEqual(1, value, "TestQueueMethods Dequeue value must be 1");
            Assert.AreEqual(2, queue.Size(), "TestSize must be 2, but not");
            value = queue.Dequeue();
            Assert.AreEqual(2, value, "TestQueueMethods Dequeue value must be 2");
            Assert.AreEqual(1, queue.Size(), "TestSize must be 1, but not");
            value = queue.Dequeue();
            Assert.AreEqual(3, value, "TestQueueMethods Dequeue value must be 3");
            Assert.AreEqual(0, queue.Size(), "TestSize must be 0, but not");
            value = queue.Dequeue();
            Assert.AreEqual(0, value, "TestQueueMethods queue is not empty");
            Assert.AreEqual(0, queue.Size(), "TestSize must be 0, but not");
        }

        [Test]
        public static void TestQueue2Methods()
        {
            var queue = new Queue2<int>();
            Assert.AreEqual(0, queue.Size(), "TestSize must be 0, but not");
            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Size(), "TestSize must be 1, but not");
            queue.Enqueue(2);
            Assert.AreEqual(2, queue.Size(), "TestSize must be 2, but not");
            queue.Enqueue(3);
            Assert.AreEqual(3, queue.Size(), "TestSize must be 3, but not");
            
            var value = queue.Dequeue();
            Assert.AreEqual(1, value, "TestQueueMethods Dequeue value must be 1");
            Assert.AreEqual(2, queue.Size(), "TestSize must be 2, but not");
            value = queue.Dequeue();
            Assert.AreEqual(2, value, "TestQueueMethods Dequeue value must be 2");
            Assert.AreEqual(1, queue.Size(), "TestSize must be 1, but not");
            value = queue.Dequeue();
            Assert.AreEqual(3, value, "TestQueueMethods Dequeue value must be 3");
            Assert.AreEqual(0, queue.Size(), "TestSize must be 0, but not");
            value = queue.Dequeue();
            Assert.AreEqual(0, value, "TestQueueMethods queue is not empty");
            Assert.AreEqual(0, queue.Size(), "TestSize must be 0, but not");
        }

        [Test]
        public static void TestShiftByMethod()
        {
            var queue = new Queue<int>();
            Assert.AreEqual(0, queue.Size(), "TestSize must be 0, but not");
            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Size(), "TestSize must be 1, but not");
            queue.Enqueue(2);
            Assert.AreEqual(2, queue.Size(), "TestSize must be 2, but not");
            queue.Enqueue(3);
            Assert.AreEqual(3, queue.Size(), "TestSize must be 3, but not");
            
            queue.ShiftBy(2);

            var value = queue.Dequeue();
            Assert.AreEqual(3, value, "TestQueueMethods Dequeue value must be 3");
            Assert.AreEqual(2, queue.Size(), "TestSize must be 2, but not");
            value = queue.Dequeue();
            Assert.AreEqual(1, value, "TestQueueMethods Dequeue value must be 1");
            Assert.AreEqual(1, queue.Size(), "TestSize must be 1, but not");
            value = queue.Dequeue();
            Assert.AreEqual(2, value, "TestQueueMethods Dequeue value must be 2");
            Assert.AreEqual(0, queue.Size(), "TestSize must be 0, but not");
            value = queue.Dequeue();
            Assert.AreEqual(0, value, "TestQueueMethods queue is not empty");
            Assert.AreEqual(0, queue.Size(), "TestSize must be 0, but not");

            
            Assert.AreEqual(0, queue.Size(), "TestSize must be 0, but not");
            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Size(), "TestSize must be 1, but not");
            queue.Enqueue(2);
            Assert.AreEqual(2, queue.Size(), "TestSize must be 2, but not");
            queue.Enqueue(3);
            Assert.AreEqual(3, queue.Size(), "TestSize must be 3, but not");
            
            queue.ShiftBy(2);
            queue.ShiftBy(1);

            value = queue.Dequeue();
            Assert.AreEqual(1, value, "TestQueueMethods Dequeue value must be 1");
            Assert.AreEqual(2, queue.Size(), "TestSize must be 2, but not");
            value = queue.Dequeue();
            Assert.AreEqual(2, value, "TestQueueMethods Dequeue value must be 2");
            Assert.AreEqual(1, queue.Size(), "TestSize must be 1, but not");
            value = queue.Dequeue();
            Assert.AreEqual(3, value, "TestQueueMethods Dequeue value must be 3");
            Assert.AreEqual(0, queue.Size(), "TestSize must be 0, but not");
            value = queue.Dequeue();
            Assert.AreEqual(0, value, "TestQueueMethods queue is not empty");
            Assert.AreEqual(0, queue.Size(), "TestSize must be 0, but not");
        }
    }
}