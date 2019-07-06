using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        private readonly List<T> list;
        public Stack()
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
            var top = list[Size() - 1];
            list.RemoveAt(Size() - 1);
            return top;
        }

        public void Push(T val)
        {
            // ваш код
            list.Add(val);
        }

        public T Peek()
        {
            // ваш код
            if (Size() == 0) return default(T); // null, если стек пустой
            return list[Size() - 1];
        }
    }

}
