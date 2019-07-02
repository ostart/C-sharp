using System;
using AlgorithmsDataStructures;

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

            var list1 = new LinkedList();
            list1.AddInTail(new Node(1));
            list1.AddInTail(new Node(2));
            list1.AddInTail(new Node(3));

            var list2 = new LinkedList();
            list2.AddInTail(new Node(4));
            list2.AddInTail(new Node(5));
            list2.AddInTail(new Node(6));

            var sum = ExtraLinkedList.AddTogether(list1, list2);

            Console.WriteLine("Hello World!");
            Console.WriteLine("The current time is " + DateTime.Now);
        }
    }
}
