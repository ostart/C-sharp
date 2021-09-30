using System.Collections;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_length;
        public BitArray bitArray;

        public BloomFilter(int filterLength)
        {
            filter_length = filterLength;
            // создаём битовый массив длиной filter_length ...
            bitArray = new BitArray(filter_length);
        }

        // хэш-функции
        public int Hash1(string inputString)
        {
            var counter = 0;
            // 17
            for (int i = 0; i < inputString.Length; i++)
            {
                int code = (int)inputString[i];
                counter = (counter * 17 + code) % filter_length;
            }
            // реализация ...
            return counter;
        }
        public int Hash2(string inputString)
        {
            // 223
            // реализация ...
            var counter = 0;
            for (int i = 0; i < inputString.Length; i++)
            {
                int code = (int)inputString[i];
                counter = (counter * 223 + code) % filter_length;
            }
            return counter;
        }

        public void Add(string inputString)
        {
            // добавляем строку inputString в фильтр
            var indexFromHash1 = Hash1(inputString);
            var indexFromHash2 = Hash2(inputString);
            bitArray.Set(indexFromHash1, true);
            bitArray.Set(indexFromHash2, true);
        }

        public bool IsValue(string inputString)
        {
            // проверка, имеется ли строка inputString в фильтре
            var indexFromHash1 = Hash1(inputString);
            var indexFromHash2 = Hash2(inputString);
            return bitArray[indexFromHash1] && bitArray[indexFromHash2];
        }
    }
}
