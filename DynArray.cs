using System;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            if(count > new_capacity) throw new ArgumentOutOfRangeException("MakeArray new capacity more than count of array element");
            if(new_capacity < 16) MakeArray(16);
            else
            {
                capacity = new_capacity;
                if (array == null) array = new T[new_capacity];
                else
                {
                    var tempArray = new T[new_capacity];
                    Array.Copy(array, tempArray, count);
                    array = tempArray;
                }
            }
        }

        public T GetItem(int index)
        {
            if(index < 0 || index >= count) throw new ArgumentOutOfRangeException("index");
            return array[index];
        }

        public void Append(T itm)
        {
            if (count + 1 > capacity) MakeArray(capacity * 2);
            array[count] = itm;
            count += 1;
        }

        public void Insert(T itm, int index)
        {
            if (index < 0 || index > count) throw new ArgumentOutOfRangeException("index");
            if (count + 1 > capacity) MakeArray(capacity*2);
            if(index == count) Append(itm);
            else
            {
                var tempArray = new T[capacity];
                if(index > 0) Array.Copy(array, tempArray, index);
                tempArray[index] = itm;
                Array.Copy(array, index, tempArray, index + 1, count - index);
                array = tempArray;
                count += 1;
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count) throw new ArgumentOutOfRangeException("index");
            var tempArray = new T[capacity];
            if (index > 0) Array.Copy(array, tempArray, index);
            Array.Copy(array, index + 1, tempArray, index, count - index - 1);
            array = tempArray;
            count -= 1;
            if(count < capacity / 2) MakeArray(capacity * 2 / 3);
        }

    }
}