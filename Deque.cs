using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    class Deque<T>
    {
        private readonly LinkedList<T> list;
        public Deque()
        {
            // инициализация внутреннего хранилища
            list = new LinkedList<T>();
        }

        public void AddFront(T item)
        {
            // добавление в голову
            list.AddFirst(item);
        }

        public void AddTail(T item)
        {
            // добавление в хвост
            list.AddLast(item);
        }

        public T RemoveFront()
        {
            // удаление из головы
            var head = list.First.Value;
            list.RemoveFirst();
            return head;
        }

        public T RemoveTail()
        {
            // удаление из хвоста
            //return default(T);
            var tail = list.Last.Value;
            list.RemoveLast();
            return tail;
        }

        public int Size()
        {
            return list.Count; // размер очереди
        }
    }

}