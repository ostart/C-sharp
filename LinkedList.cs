using System.Collections.Generic;

namespace AlgorithmsDataStructuresLinkedList
{
    public class Node
   {
     public int value;
     public Node next;
     public Node(int _value) { value = _value; }
   }

   public class LinkedList
   {
     public Node head;
     public Node tail;

     public LinkedList()
     {
       head = null;
       tail = null;
     }

     public void AddInTail(Node _item)
     {
       if (head == null) head = _item;
       else              tail.next = _item;
       tail = _item;
     }

     public Node Find(int _value)
     {
       Node node = head;
       while (node != null)
       {
         if (node.value == _value) return node;
         node = node.next;
       }
       return null;
     }

     public List<Node> FindAll(int _value)
     {
       List<Node> nodes = new List<Node>();
       // здесь будет ваш код поиска всех узлов по заданному значению
       Node node = head;
       while (node != null)
       {
         if (node.value == _value) nodes.Add(node);
         node = node.next;
       }
       return nodes;
     }

     public bool Remove(int _value)
     {
       // здесь будет ваш код удаления одного узла по заданному значению
       Node node = head;
       Node prev = null;
       while (node != null)
       {
         if (node.value == _value) 
         {
            if(prev == null) head = node.next;
            else             prev.next = node.next;
            if(node.next == null) tail = prev;
            return true;
         }
         prev = node;
         node = node.next;
       }
       return false; // если узел был удалён
     }

     public void RemoveAll(int _value)
     {
       // здесь будет ваш код удаления всех узлов по заданному значению
       while (Remove(_value)) {}
     }

     public void Clear()
     {
       // здесь будет ваш код очистки всего списка
       head = null;
       tail = null;
     }

     public int Count()
     {
       int counter = 0;
       Node node = head;
       while (node != null)
       {
         counter += 1;
         node = node.next;
       }
       return counter; // здесь будет ваш код подсчёта количества элементов в списке
     }

     public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
     {
       // здесь будет ваш код вставки узла после заданного
       if(_nodeAfter == null && Count() == 0) AddInTail(_nodeToInsert);
       else 
       {
          Node node = head;
          while (node != null)
          {
            if (node.value == _nodeAfter.value) {
              if(node.next == null) tail = _nodeToInsert;
              _nodeToInsert.next = node.next;
              node.next = _nodeToInsert;
              return;
            }
            node = node.next;
          }
       }
       // если _nodeAfter = null и список пустой, 
       // добавьте новый элемент первым в списке 
     }
    }
}