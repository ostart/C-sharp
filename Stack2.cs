using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack2<T>
    {
        private readonly DynArray<T> array;
        public Stack2()
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
            var head = array.GetItem(0);
            array.Remove(0);
            return head;
        }

        public void Push(T val)
        {
            // ваш код
            array.Insert(val, 0);
        }

        public T Peek()
        {
            // ваш код
            if (array.count == 0) return default(T); // null, если стек пустой
            return array.GetItem(0);
        }
    }

}
