using NUnit.Framework;
using AlgorithmsDataStructures;

namespace Tests
{
    public class TestsLinkedList2
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public static void TestAddInTail()
        {
            var testList = new LinkedList2();
            Assert.AreEqual(0, testList.Count(), "Test TestAddInTail failed. Initial list count have to be equal 0");
            testList.AddInTail(new Node(1));
            Assert.AreEqual(1, testList.Count(), "Test TestAddInTail failed. List count have to be equal 1");
            testList.AddInTail(new Node(2));
            Assert.AreEqual(2, testList.Count(), "Test TestAddInTail failed. List count have to be equal 2");
            testList.AddInTail(new Node(3));
            Assert.AreEqual(3, testList.Count(), "Test TestAddInTail failed. List count have to be equal 3");
            Assert.IsNull(testList.tail.next, "Test TestAddInTail failed. List tail.next not equal NULL");
        }

        [Test]
        public static void TestRemove()
        {
            var testList = new LinkedList2();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.Remove(1);
            Assert.AreEqual(2, testList.Count(), "Test TestRemove failed. List count have to be equal 2");
            testList.Remove(3);
            Assert.AreEqual(1, testList.Count(), "Test TestRemove failed. List count have to be equal 1");
            Assert.AreSame(testList.head, testList.tail, "Test TestRemove failed. List head not equal tail");
            Assert.IsNull(testList.tail.next, "Test TestRemove failed. List tail.next not equal NULL");
            testList.Remove(2);
            Assert.AreEqual(0, testList.Count(), "Test TestRemove failed. List count have to be equal 0");
            Assert.IsNull(testList.head, "Test TestRemove failed. List not empty");
            Assert.IsNull(testList.tail, "Test TestRemove failed. List not empty");
        }

        [Test]
        public static void TestRemoveAll()
        {
            var testList = new LinkedList2();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(1));
            testList.RemoveAll(1);
            Assert.AreEqual(2, testList.Count(), "Test TestRemoveAll failed. List count have to be equal 2");
            Assert.AreEqual(2, testList.head.value, "Test TestRemoveAll failed. List head not equal 2");
            Assert.AreEqual(3, testList.tail.value, "Test TestRemoveAll failed. List tail not equal 3");
            Assert.IsNull(testList.tail.next, "Test TestRemoveAll failed. List tail.next not equal NULL");
            Assert.IsNull(testList.head.prev, "Test TestRemoveAll failed. List head.prev not equal NULL");
            Assert.IsNotNull(testList.head.next, "Test TestRemoveAll failed. List head.next not equal NOT NULL");
            Assert.IsNotNull(testList.tail.prev, "Test TestRemoveAll failed. List tail.prev not equal NOT NULL");
        }

        [Test]
        public static void TestFind()
        {
            var testList = new LinkedList2();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            var found = testList.Find(2);
            Assert.AreSame(testList.head.next, found, "Test TestFind failed. List head.next not equal found");
            Assert.AreEqual(2, found.value, "Test TestFind failed. List found not equal 2");
            Assert.AreEqual(3, found.next.value, "Test TestFind failed. List found.next not equal 3");
            Assert.AreEqual(1, found.prev.value, "Test TestFind failed. List found.prev not equal 1");
        }

        [Test]
        public static void TestFindAll()
        {
            var testList = new LinkedList2();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(4));
            var foundList = testList.FindAll(1);
            Assert.AreEqual(3, foundList.Count, "Test TestFindAll failed. List foundList count not equal 3");
        }

        [Test]
        public static void TestClear()
        {
            var testList = new LinkedList2();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(4));
            testList.Clear();
            Assert.AreEqual(0, testList.Count(), "Test TestClear failed. List count not equal 0");
        }

        [Test]
        public static void TestInsertAfter()
        {
            var testList = new LinkedList2();
            testList.InsertAfter(null, new Node(1));
            Assert.AreEqual(1, testList.Count(), "Test TestInsertAfter failed. List count have to be equal 1");
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(5));
            testList.InsertAfter(new Node(3), new Node(4));
            Assert.AreEqual(4, testList.Count(), "Test TestInsertAfter failed. List count have to be equal 4");
            testList.InsertAfter(new Node(1), new Node(2));
            Assert.AreEqual(5, testList.Count(), "Test TestInsertAfter failed. List count have to be equal 5");
            testList.InsertAfter(new Node(5), new Node(6));
            Assert.AreEqual(6, testList.Count(), "Test TestInsertAfter failed. List count have to be equal 6");
            testList.InsertAfter(null, new Node(0));
            Assert.AreEqual(7, testList.Count(), "Test TestInsertAfter failed. List count have to be equal 7");
            Assert.AreEqual(0, testList.head.value, "Test TestInsertAfter failed. List head.value have to be equal 0");
            Assert.AreEqual(6, testList.tail.value, "Test TestInsertAfter failed. List tail.value have to be equal 6");
            Assert.IsNull(testList.tail.next, "Test TestInsertAfter failed. List tail.next have to be equal NULL");
            Assert.IsNull(testList.head.prev, "Test TestInsertAfter failed. List head.prev have to be equal NULL");
            Assert.IsNotNull(testList.tail.prev, "Test TestInsertAfter failed. List tail.prev have to be equal NOT NULL");
            Assert.IsNotNull(testList.head.next, "Test TestInsertAfter failed. List head.next have to be equal NOT NULL");

            int counter = -1;
            Node node = testList.head;
            while (node != null)
            {
                counter += 1;
                Assert.AreEqual(counter, node.value, "Test TestInsertAfter failed. List sequence is not correct");
                node = node.next;
            }
        }
    }
}