using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack2<T>
    {
        private readonly List<T> list;
        public Stack2()
        {
            // инициализация внутреннего хранилища стека
            list = new List<T>();
        }

        public int Size()
        {
            // размер текущего стека		  
            return list.Count;
        }

        public T Pop()
        {
            // ваш код
            if(Size() == 0) return default(T); // null, если стек пустой
            var head = list[0];
            list.RemoveAt(0);
            return head;
        }

        public void Push(T val)
        {
            // ваш код
            list.Insert(0, val);
        }

        public T Peek()
        {
            // ваш код
            if (Size() == 0) return default(T); // null, если стек пустой
            return list[0];
        }
    }

}
