using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            int result = 0;
            if (typeof(T) == typeof(String))
            {
                // версия для лексикографического сравнения строк
                var str1 = v1.ToString().Trim();
                var str2 = v2.ToString().Trim();
                result = string.CompareOrdinal(str1, str2);
            }
            else
            {
                // универсальное сравнение
                object var1 = v1;
                object var2 = v2;
                var d1 = Convert.ToDecimal(var1);
                var d2 = Convert.ToDecimal(var2);
                if (d1 > d2) result = 1;
                else if (d1 < d2) result = -1;
                else result = 0;
            }

            return result;
            // -1 если v1 < v2
            // 0 если v1 == v2
            // +1 если v1 > v2
        }

        public void Add(T value)
        {
            // автоматическая вставка value 
            // в нужную позицию
            if (head == null)
            {
                head = new Node<T>(value);
                tail = head;
            }
            else
            {
                Node<T> node = head;
                while (node != null)
                {
                    var comparer = _ascending ? Compare(node.value, value) : Compare(value, node.value);
                    if (comparer == 1)
                    {
                        var inserted = new Node<T>(value);
                        inserted.prev = node.prev;
                        inserted.next = node;
                        if (node.prev != null) node.prev.next = inserted;
                        else head = inserted;
                        node.prev = inserted;
                        return;
                    }
                    node = node.next;
                }
                var addToTail = new Node<T>(value);
                addToTail.prev = tail;
                tail.next = addToTail;
                tail = addToTail;
            }
        }

        public Node<T> Find(T val)
        {
            Node<T> node = head;
            while (node != null)
            {
                var result = _ascending ? Compare(node.value, val) : Compare(val, node.value);
                if (result == 0) return node;
                if (result == 1) return null;
                node = node.next;
            }
            return null; // здесь будет ваш код
        }

        public void Delete(T val)
        {
            // здесь будет ваш код
            var nodeToDelete = Find(val);
            if (nodeToDelete != null)
            {
                if (nodeToDelete.prev != null) nodeToDelete.prev.next = nodeToDelete.next;
                else head = nodeToDelete.next;
                if (nodeToDelete.next != null) nodeToDelete.next.prev = nodeToDelete.prev;
                else tail = nodeToDelete.prev;
            }
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            // здесь будет ваш код
            head = null;
            tail = null;
        }

        public int Count()
        {
            int counter = 0;
            Node<T> node = head;
            while (node != null)
            {
                counter += 1;
                node = node.next;
            }
            return counter; // здесь будет ваш код подсчёта количества элементов в списке
        }

        List<Node<T>> GetAll()
        {
            List<Node<T>> resultListOfNodes = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                resultListOfNodes.Add(node);
                node = node.next;
            }
            return resultListOfNodes;
        }
    }

}
