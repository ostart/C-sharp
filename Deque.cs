using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    class Deque<T>
    {
        private readonly LinkedList<T> internalStorageList;
        public Deque()
        {
            // инициализация внутреннего хранилища
            internalStorageList = new LinkedList<T>();
        }

        public void AddFront(T item)
        {
            // добавление в голову
            internalStorageList.AddFirst(item);
        }

        public void AddTail(T item)
        {
            // добавление в хвост
            internalStorageList.AddLast(item);
        }

        public T RemoveFront()
        {
            // удаление из головы
            if(Size() == 0) return default(T);
            var head = internalStorageList.First.Value;
            internalStorageList.RemoveFirst();
            return head;
        }

        public T RemoveTail()
        {
            // удаление из хвоста
            if(Size() == 0) return default(T);
            var tail = internalStorageList.Last.Value;
            internalStorageList.RemoveLast();
            return tail;
        }

        public int Size()
        {
            return internalStorageList.Count; // размер очереди
        }

        public T PeekFront()
        {
            return internalStorageList.First.Value;
        }

        public T PeekTail()
        {
            return internalStorageList.Last.Value;
        }
    }

}