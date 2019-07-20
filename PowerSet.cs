using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures
{

    // наследуйте этот класс от HashTable
    // или расширьте его методами из HashTable
    public class PowerSet<T>: HashTable
    {

        public PowerSet() : base(20000, 1)
        {
            // ваша реализация хранилища
        }

        public int Size()
        {
            // количество элементов в множестве
            return slots.Count(slot => slot != null);
        }

        public void Put(T value)
        {
            // всегда срабатывает
            var strValue = value.ToString();
            if (Find(strValue) == -1)
                Put(strValue);
        }

        public bool Get(T value)
        {
            // возвращает true если value имеется в множестве,
            // иначе false
            var strValue = value.ToString();
            return Find(strValue) != -1;
        }

        public bool Remove(T value)
        {
            // возвращает true если value удалено
            // иначе false
            var strValue = value.ToString();
            var index = Find(strValue);
            var result =  index != -1;
            if (result) slots[index] = null;
            return result;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            // пересечение текущего множества и set2
            var currValues = slots.Where(slot => slot != null);
            var set2Values = set2.slots.Where(slot => slot != null);
            var result = new PowerSet<T>();
            foreach (var currValue in currValues)
            {
                if (set2Values.Contains(currValue)) result.Put(currValue);
            }
            return result.Size() == 0 ? null : result;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            // объединение текущего множества и set2
            var currValues = slots.Where(slot => slot != null);
            var set2Values = set2.slots.Where(slot => slot != null);
            var result = new PowerSet<T>();
            foreach (var currValue in currValues)
            {
                var obj = (T)Convert.ChangeType(currValue, typeof(T));
                result.Put(obj);
            }
            foreach (var value in set2Values)
            {
                var obj = (T)Convert.ChangeType(value, typeof(T));
                result.Put(obj);
            }
            return result.Size() == 0 ? null : result;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            // разница текущего множества и set2
            var currValues = slots.Where(slot => slot != null);
            var set2Values = set2.slots.Where(slot => slot != null);
            var result = new PowerSet<T>();
            foreach (var currValue in currValues)
            {
                if (!set2Values.Contains(currValue)) result.Put(currValue);
            }
            return result.Size() == 0 ? null : result;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            // возвращает true, если set2 есть
            // подмножество текущего множества,
            // иначе false
            var currValues = slots.Where(slot => slot != null);
            var set2Values = set2.slots.Where(slot => slot != null);
            foreach (var set2Value in set2Values)
            {
                if (!currValues.Contains(set2Value)) return false;
            }
            return true;
        }
    }

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
