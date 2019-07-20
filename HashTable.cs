using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructuresHashTable
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            // всегда возвращает корректный индекс слота
            var total = 0;
            var c = value.ToCharArray();
            for (var i = 0; i <= c.GetUpperBound(0); i++)
                total += (int)c[i];

            return total % size;
        }

        public int SeekSlot(string value)
        {
            // находит индекс пустого слота для значения, или -1
            var initIndex = HashFun(value);
            if (slots[initIndex] == null) return initIndex;
            var current = initIndex;
            do
            {
                current += step;
                if (slots[current % size] == null) return current % size;
            } while (current % size != initIndex);

            return -1;
        }

        public int Put(string value)
        {
            // записываем значение по хэш-функции
            var index = SeekSlot(value);
            if (index != -1)
            {
                slots[index] = value;
                return index;
            }
            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            return -1;
        }

        public int Find(string value)
        {
            // находит индекс слота со значением, или -1
            var initIndex = HashFun(value);
            if (slots[initIndex] == value) return initIndex;
            var current = initIndex;
            do
            {
                current += step;
                if (slots[current % size] == value) return current % size;
            } while (current % size != initIndex);

            return -1;
        }
    }

}