using System;

namespace AlgorithmsDataStructures
{
    public class TestsLinkedList
    {
        public static void TestAddInTail()
        {
            var testList = new LinkedList();
            if(testList.Count() != 0) 
            {
                throw new Exception("Test TestAddInTail failed. Initial list count have to be equal 0");
            }
            testList.AddInTail(new Node(1));
            if(testList.Count() != 1) 
            {
                throw new Exception("Test TestAddInTail failed. List count have to be equal 3");
            }
            testList.AddInTail(new Node(2));
            if(testList.Count() != 2) 
            {
                throw new Exception("Test TestAddInTail failed. List count have to be equal 3");
            }
            testList.AddInTail(new Node(3));
            if(testList.Count() != 3) 
            {
                throw new Exception("Test TestAddInTail failed. List count have to be equal 3");
            }
            if(testList.tail.next != null) 
            {
                throw new Exception("Test TestAddInTail failed. List tail.next not equal NULL");
            }
        }

        public static void TestRemove()
        {
            var testList = new LinkedList();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.Remove(1);
            if(testList.Count() != 2) 
            {
                throw new Exception("Test TestRemove failed. List count have to be equal 2");
            }
            testList.Remove(3);
            if(testList.Count() != 1) 
            {
                throw new Exception("Test TestRemove failed. List count have to be equal 1");
            }
            if(testList.head != testList.tail) 
            {
                throw new Exception("Test TestRemove failed. List head not equal tail");
            }
            if(testList.tail.next != null) 
            {
                throw new Exception("Test TestRemove failed. List tail.next not equal NULL");
            }
            testList.Remove(2);
            if(testList.Count() != 0) 
            {
                throw new Exception("Test TestRemove failed. List count have to be equal 1");
            }
            if(testList.head != null && testList.tail != null) 
            {
                throw new Exception("Test TestRemove failed. List not empty");
            }
        }

        public static void TestRemoveAll()
        {
            var testList = new LinkedList();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(1));
            testList.RemoveAll(1);
            if(testList.Count() != 2) 
            {
                throw new Exception("Test TestRemoveAll failed. List count have to be equal 2");
            }
            if(testList.head.value != 2) 
            {
                throw new Exception("Test TestRemoveAll failed. List head not equal 2");
            }
            if(testList.tail.value != 3) 
            {
                throw new Exception("Test TestRemoveAll failed. List tail not equal 3");
            }
            if(testList.tail.next != null) 
            {
                throw new Exception("Test TestRemoveAll failed. List tail.next not equal NULL");
            }
        }

        public static void TestFind()
        {
            var testList = new LinkedList();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(4));
            testList.AddInTail(new Node(5));
            var found = testList.Find(2);
            if(testList.head.next != found) 
            {
                throw new Exception("Test TestFind failed. List head.next not equal found");
            }
            if(found.value != 2) 
            {
                throw new Exception("Test TestFind failed. List found not equal 2");
            }
            if(found.next.value != 3) 
            {
                throw new Exception("Test TestFind failed. List found.next not equal 3");
            }
        }

        public static void TestFindAll()
        {
            var testList = new LinkedList();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(4));
            var foundList = testList.FindAll(1);
            if(foundList.Count != 3) 
            {
                throw new Exception("Test TestFindAll failed. List foundList count not equal 3");
            }
        }

        public static void TestClear()
        {
            var testList = new LinkedList();
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(2));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(1));
            testList.AddInTail(new Node(4));
            testList.Clear();
            if(testList.Count() != 0) 
            {
                throw new Exception("Test TestClear failed. List count not equal 0");
            }
        }

        public static void TestInsertAfter()
        {
            var testList = new LinkedList();
            testList.InsertAfter(null, new Node(1));
            if(testList.Count() != 1) 
            {
                throw new Exception("Test TestInsertAfter failed. List count have to be equal 1");
            }
            testList.AddInTail(new Node(3));
            testList.AddInTail(new Node(5));
            testList.InsertAfter(new Node(3), new Node(4));
            if(testList.Count() != 4) 
            {
                throw new Exception("Test TestInsertAfter failed. List count have to be equal 4");
            }
            testList.InsertAfter(new Node(1), new Node(2));
            if(testList.Count() != 5) 
            {
                throw new Exception("Test TestInsertAfter failed. List count have to be equal 5");
            }
            testList.InsertAfter(new Node(5), new Node(6));
            if(testList.Count() != 6) 
            {
                throw new Exception("Test TestInsertAfter failed. List count have to be equal 7");
            }
            if(testList.tail.value != 6) 
            {
                throw new Exception("Test TestInsertAfter failed. List tail.value have to be equal 6");
            }
            if(testList.tail.next != null) 
            {
                throw new Exception("Test TestInsertAfter failed. List tail.next have to be equal NULL");
            }
            int counter = 0;
            Node node = testList.head;
            while (node != null)
            {
            counter += 1;
            if(counter != node.value)
            {
                throw new Exception("Test TestInsertAfter failed. List sequence is not correct");
            }
            node = node.next;
            }
        }
    }
}