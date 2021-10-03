using System;
using AlgorithmsDataStructuresLinkedList;

namespace C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestsLinkedList.TestAddInTail();
            TestsLinkedList.TestRemove();
            TestsLinkedList.TestRemoveAll();
            TestsLinkedList.TestFind();
            TestsLinkedList.TestFindAll();
            TestsLinkedList.TestClear();
            TestsLinkedList.TestInsertAfter();

            var firstTermList = new LinkedList();
            firstTermList.AddInTail(new Node(1));
            firstTermList.AddInTail(new Node(2));
            firstTermList.AddInTail(new Node(3));

            var lastTermList = new LinkedList();
            lastTermList.AddInTail(new Node(4));
            lastTermList.AddInTail(new Node(5));
            lastTermList.AddInTail(new Node(6));

            var summaryList = LinkedListExtra.AddTogether(firstTermList, lastTermList);

            Console.WriteLine("Hello World!");
            Console.WriteLine("The current time is " + DateTime.Now);
        }
    }
}
