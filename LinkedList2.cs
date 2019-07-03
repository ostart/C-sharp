using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            // здесь будет ваш код поиска
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
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node.prev == null && node.next == null)
                    {
                        head = null;
                        tail = null;
                    }
                    else if (node.prev == null)
                    {
                        head = node.next;
                        node.next.prev = null;
                    }
                    else if(node.next == null)
                    {
                        tail = node.prev;
                        node.prev.next = null;
                    }
                    else 
                    {
                        node.prev.next = node.next;
                        node.next.prev = node.prev;
                    }
                    return true; // если узел был удалён
                }
                node = node.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            // здесь будет ваш код удаления всех узлов по заданному значению
            while (Remove(_value)) { }
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
            // здесь будет ваш код вставки узла после заданного узла
            if (_nodeAfter == null)
            {
                if (Count() == 0) AddInTail(_nodeToInsert);
                else
                {
                    _nodeToInsert.next = head;
                    head.prev = _nodeToInsert;
                    head = _nodeToInsert;
                }
            }
            else
            {
                Node node = head;
                while (node != null)
                {
                    if (node.value == _nodeAfter.value)
                    {
                        if (node.next == null) tail = _nodeToInsert;
                        _nodeToInsert.next = node.next;
                        _nodeToInsert.prev = node;
                        node.next = _nodeToInsert;
                        return;
                    }
                    node = node.next;
                }
            }
            // если _nodeAfter = null
            // добавьте новый элемент первым в списке 
        }
    }
}