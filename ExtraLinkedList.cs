using System;

namespace AlgorithmsDataStructuresLinkedList
{
    public class ExtraLinkedList
    {
        public static LinkedList AddTogether(LinkedList list1, LinkedList list2)
        {
            if(list1.Count() != list2.Count()) throw new Exception("Can't add together lists with different length");
            var result = new LinkedList();
            Node node1 = list1.head;
            Node node2 = list2.head;
            while (node1 != null)
            {
                result.AddInTail(new Node(node1.value + node2.value));
                node1 = node1.next;
                node2 = node2.next;
            }
            return result;
        }
    }
}
