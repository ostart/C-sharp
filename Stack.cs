using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        private readonly DynArray<T> array;
        public Stack()
        {
            // инициализация внутреннего хранилища стека
            array = new DynArray<T>();
        }

        public int Size()
        {
            // размер текущего стека		  
            return array.count;
        }

        public T Pop()
        {
            // ваш код
            if(array.count == 0) return default(T); // null, если стек пустой
            var top = array.GetItem(array.count - 1);
            array.Remove(array.count - 1);
            return top;
        }

        public void Push(T val)
        {
            // ваш код
            array.Append(val);
        }

        public T Peek()
        {
            // ваш код
            if (array.count == 0) return default(T); // null, если стек пустой
            return array.GetItem(array.count - 1);
        }
    }

}
