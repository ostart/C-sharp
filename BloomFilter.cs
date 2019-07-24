using System.Collections.Generic;
using System;
using System.Collections;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        public BitArray bitArray;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            // создаём битовый массив длиной f_len ...
            bitArray = new BitArray(filter_len);
        }

        // хэш-функции
        public int Hash1(string str1)
        {
            var counter = 0;
            // 17
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                counter = (counter * 17 + code) % filter_len;
            }
            // реализация ...
            return counter;
        }
        public int Hash2(string str1)
        {
            // 223
            // реализация ...
            var counter = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                counter = (counter * 223 + code) % filter_len;
            }
            return counter;
        }

        public void Add(string str1)
        {
            // добавляем строку str1 в фильтр
            var index1 = Hash1(str1);
            var index2 = Hash2(str1);
            bitArray.Set(index1, true);
            bitArray.Set(index2, true);
        }

        public bool IsValue(string str1)
        {
            // проверка, имеется ли строка str1 в фильтре
            var index1 = Hash1(str1);
            var index2 = Hash2(str1);
            return bitArray[index1] && bitArray[index2];
        }
    }
}
