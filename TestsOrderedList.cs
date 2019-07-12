using System.Collections.Generic;
using NUnit.Framework;
using AlgorithmsDataStructures;

namespace Tests
{
    public class TestsOrderedList
    {
        [Test]
        public static void TestAddOrderedListIntAsc()
        {
            var list = new OrderedList<int>(true);
            Assert.AreEqual(0, list.Count(), "TestAddOrderedListIntAsc orderedList size must be 0, but not");
            list.Add(1);
            Assert.AreEqual(1, list.Count(), "TestAddOrderedListIntAsc orderedList size must be 1, but not");
            list.Add(3);
            Assert.AreEqual(2, list.Count(), "TestAddOrderedListIntAsc orderedList size must be 2, but not");
            list.Add(4);
            Assert.AreEqual(3, list.Count(), "TestAddOrderedListIntAsc orderedList size must be 3, but not");
            list.Add(2);
            Assert.AreEqual(4, list.Count(), "TestAddOrderedListIntAsc orderedList size must be 4, but not");
            list.Add(0);
            Assert.AreEqual(5, list.Count(), "TestAddOrderedListIntAsc orderedList size must be 5, but not");
            list.Add(-1);
            Assert.AreEqual(6, list.Count(), "TestAddOrderedListIntAsc orderedList size must be 6, but not");

            var counter = -1;
            var node = list.head;
            while (node != null)
            {
                Assert.AreEqual(counter, node.value, "Test TestAddOrderedListIntAsc failed. List sequence is not correct");
                counter += 1;
                node = node.next;
            }
            Assert.AreEqual(5, counter, "TestAddOrderedListIntAsc counter must be 6, but not");
        }

        [Test]
        public static void TestAddOrderedListStringAsc()
        {
            var list = new OrderedList<string>(true);
            var etalon = new Dictionary<int, string>();
            Assert.AreEqual(0, list.Count(), "TestAddOrderedListStringAsc orderedList size must be 0, but not");
            list.Add("c");
            etalon.Add(1, "c");
            Assert.AreEqual(1, list.Count(), "TestAddOrderedListStringAsc orderedList size must be 1, but not");
            list.Add("e");
            etalon.Add(3, "e");
            Assert.AreEqual(2, list.Count(), "TestAddOrderedListStringAsc orderedList size must be 2, but not");
            list.Add("f");
            etalon.Add(4, "f");
            Assert.AreEqual(3, list.Count(), "TestAddOrderedListStringAsc orderedList size must be 3, but not");
            list.Add("d");
            etalon.Add(2, "d");
            Assert.AreEqual(4, list.Count(), "TestAddOrderedListStringAsc orderedList size must be 4, but not");
            list.Add("b");
            etalon.Add(0, "b");
            Assert.AreEqual(5, list.Count(), "TestAddOrderedListStringAsc orderedList size must be 5, but not");
            list.Add("a");
            etalon.Add(-1, "a");
            Assert.AreEqual(6, list.Count(), "TestAddOrderedListStringAsc orderedList size must be 6, but not");

            var counter = -1;
            var node = list.head;
            while (node != null)
            {
                Assert.AreEqual(etalon[counter], node.value, "Test TestAddOrderedListStringAsc failed. List sequence is not correct");
                counter += 1;
                node = node.next;
            }
            Assert.AreEqual(5, counter, "TestAddOrderedListStringAsc counter must be 6, but not");
        }

        [Test]
        public static void TestAddOrderedListIntDesc()
        {
            var list = new OrderedList<int>(false);
            Assert.AreEqual(0, list.Count(), "TestAddOrderedListIntDesc orderedList size must be 0, but not");
            list.Add(4);
            Assert.AreEqual(1, list.Count(), "TestAddOrderedListIntDesc orderedList size must be 1, but not");
            list.Add(2);
            Assert.AreEqual(2, list.Count(), "TestAddOrderedListIntDesc orderedList size must be 2, but not");
            list.Add(3);
            Assert.AreEqual(3, list.Count(), "TestAddOrderedListIntDesc orderedList size must be 3, but not");
            list.Add(1);
            Assert.AreEqual(4, list.Count(), "TestAddOrderedListIntDesc orderedList size must be 4, but not");
            list.Add(5);
            Assert.AreEqual(5, list.Count(), "TestAddOrderedListIntDesc orderedList size must be 5, but not");
            list.Add(6);
            Assert.AreEqual(6, list.Count(), "TestAddOrderedListIntDesc orderedList size must be 6, but not");

            var counter = 6;
            var node = list.head;
            while (node != null)
            {
                Assert.AreEqual(counter, node.value, "Test TestAddOrderedListIntDesc failed. List sequence is not correct");
                counter -= 1;
                node = node.next;
            }
            Assert.AreEqual(0, counter, "TestAddOrderedListIntDesc counter must be 0, but not");
        }

        [Test]
        public static void TestAddOrderedListStringDesc()
        {
            var list = new OrderedList<string>(false);
            var etalon = new Dictionary<int, string>();
            Assert.AreEqual(0, list.Count(), "TestAddOrderedListStringAsc orderedList size must be 0, but not");
            list.Add("e");
            etalon.Add(0, "e");
            Assert.AreEqual(1, list.Count(), "TestAddOrderedListStringAsc orderedList size must be 1, but not");
            list.Add("b");
            etalon.Add(3, "b");
            Assert.AreEqual(2, list.Count(), "TestAddOrderedListStringAsc orderedList size must be 2, but not");
            list.Add("c");
            etalon.Add(2, "c");
            Assert.AreEqual(3, list.Count(), "TestAddOrderedListStringAsc orderedList size must be 3, but not");
            list.Add("d");
            etalon.Add(1, "d");
            Assert.AreEqual(4, list.Count(), "TestAddOrderedListStringAsc orderedList size must be 4, but not");
            list.Add("a");
            etalon.Add(4, "a");
            Assert.AreEqual(5, list.Count(), "TestAddOrderedListStringAsc orderedList size must be 5, but not");
            list.Add("f");
            etalon.Add(-1, "f");
            Assert.AreEqual(6, list.Count(), "TestAddOrderedListStringAsc orderedList size must be 6, but not");

            var counter = -1;
            var node = list.head;
            while (node != null)
            {
                Assert.AreEqual(etalon[counter], node.value, "Test TestAddOrderedListStringAsc failed. List sequence is not correct");
                counter += 1;
                node = node.next;
            }
            Assert.AreEqual(5, counter, "TestAddOrderedListStringAsc counter must be 6, but not");
        }

        [Test]
        public static void TestRemoveOrderedListIntAsc()
        {
            var list = new OrderedList<int>(true);
            Assert.AreEqual(0, list.Count(), "TestRemoveOrderedListIntAsc orderedList size must be 0, but not");
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.Count(), "TestRemoveOrderedListIntAsc orderedList size must be 3, but not");
            
            var counter = 1;
            var node = list.head;
            while (node != null)
            {
                Assert.AreEqual(counter, node.value, "Test TestAddOrderedListIntDesc failed. List sequence is not correct");
                counter += 1;
                node = node.next;
            }
            
            list.Delete(4);
            Assert.AreEqual(3, list.Count(), "TestRemoveOrderedListIntAsc orderedList size must be 3, but not");
            list.Delete(2);
            Assert.AreEqual(2, list.Count(), "TestRemoveOrderedListIntAsc orderedList size must be 2, but not");
            counter = 1;
            node = list.head;
            while (node != null)
            {
                Assert.AreEqual(counter, node.value, "Test TestAddOrderedListIntDesc failed. List sequence is not correct");
                counter += 2;
                node = node.next;
            }

            list.Delete(3);
            Assert.AreEqual(1, list.Count(), "TestRemoveOrderedListIntAsc orderedList size must be 1, but not");
            counter = 1;
            node = list.head;
            while (node != null)
            {
                Assert.AreEqual(counter, node.value, "Test TestAddOrderedListIntDesc failed. List sequence is not correct");
                counter += 1;
                node = node.next;
            }

            list.Delete(1);
            Assert.AreEqual(0, list.Count(), "TestRemoveOrderedListIntAsc orderedList size must be 0, but not");

            list.Delete(1);
            Assert.AreEqual(0, list.Count(), "TestRemoveOrderedListIntAsc orderedList size must be 0, but not");
        }

        [Test]
        public static void TestRemoveOrderedListIntDesc()
        {
            var list = new OrderedList<int>(false);
            Assert.AreEqual(0, list.Count(), "TestRemoveOrderedListIntDesc orderedList size must be 0, but not");
            list.Add(4);
            list.Add(3);
            list.Add(2);
            list.Add(1);
            Assert.AreEqual(4, list.Count(), "TestRemoveOrderedListIntDesc orderedList size must be 4, but not");

            var counter = 4;
            var node = list.head;
            while (node != null)
            {
                Assert.AreEqual(counter, node.value, "Test TestRemoveOrderedListIntDesc failed. List sequence is not correct");
                counter -= 1;
                node = node.next;
            }

            list.Delete(3);
            Assert.AreEqual(3, list.Count(), "TestRemoveOrderedListIntDesc orderedList size must be 3, but not");
            list.Delete(2);
            Assert.AreEqual(2, list.Count(), "TestRemoveOrderedListIntDesc orderedList size must be 2, but not");
            counter = 4;
            node = list.head;
            while (node != null)
            {
                Assert.AreEqual(counter, node.value, "Test TestRemoveOrderedListIntDesc failed. List sequence is not correct");
                counter -= 3;
                node = node.next;
            }

            list.Delete(1);
            Assert.AreEqual(1, list.Count(), "TestRemoveOrderedListIntDesc orderedList size must be 1, but not");
            counter = 4;
            node = list.head;
            while (node != null)
            {
                Assert.AreEqual(counter, node.value, "Test TestRemoveOrderedListIntDesc failed. List sequence is not correct");
                counter -= 1;
                node = node.next;
            }

            list.Delete(4);
            Assert.AreEqual(0, list.Count(), "TestRemoveOrderedListIntDesc orderedList size must be 0, but not");

            list.Delete(4);
            Assert.AreEqual(0, list.Count(), "TestRemoveOrderedListIntAsc orderedList size must be 0, but not");
        }

        [Test]
        public static void TestFindOrderedListIntAsc()
        {
            var list = new OrderedList<int>(true);
            Assert.AreEqual(0, list.Count(), "TestFindOrderedListIntAsc orderedList size must be 0, but not");
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            Assert.AreEqual(4, list.Count(), "TestFindOrderedListIntAsc orderedList size must be 4, but not");

            var found = list.Find(3);
            Assert.AreEqual(3, found.value);
            Assert.AreEqual(2, found.prev.value);
            Assert.AreEqual(4, found.next.value);

            found = list.Find(4);
            Assert.AreEqual(4, found.value);
            Assert.AreEqual(3, found.prev.value);
            Assert.IsNull(found.next);

            found = list.Find(1);
            Assert.AreEqual(1, found.value);
            Assert.AreEqual(2, found.next.value);
            Assert.IsNull(found.prev);
        }

        [Test]
        public static void TestFindOrderedListIntDesc()
        {
            var list = new OrderedList<int>(false);
            Assert.AreEqual(0, list.Count(), "TestFindOrderedListIntAsc orderedList size must be 0, but not");
            list.Add(4);
            list.Add(3);
            list.Add(2);
            list.Add(1);
            Assert.AreEqual(4, list.Count(), "TestFindOrderedListIntAsc orderedList size must be 4, but not");

            var found = list.Find(3);
            Assert.AreEqual(3, found.value);
            Assert.AreEqual(4, found.prev.value);
            Assert.AreEqual(2, found.next.value);

            found = list.Find(4);
            Assert.AreEqual(4, found.value);
            Assert.AreEqual(3, found.next.value);
            Assert.IsNull(found.prev);

            found = list.Find(1);
            Assert.AreEqual(1, found.value);
            Assert.AreEqual(2, found.prev.value);
            Assert.IsNull(found.next);
        }
    }
}
