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

        public int CalculateHashFunction(string value)
        {
            // всегда возвращает корректный индекс слота
            var charArray = value.ToCharArray();
            var total = 0;
            for (var i = 0; i <= charArray.GetUpperBound(0); i++)
                total += (int)charArray[i];

            return total % size;
        }

        public int SeekSlot(string value)
        {
            // находит индекс пустого слота для значения, или -1
            var initIndex = CalculateHashFunction(value);
            if (slots[initIndex] == null) return initIndex;
            var current = initIndex;
            do
            {
                current += step;
                if (slots[current % size] == null) return current % size;
            } while (current % size != initIndex);

            return -1;
        }

        public int PutAndReturnNewSlotIndex(string value)
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

        public int FindSlotIndex(string value)
        {
            // находит индекс слота со значением, или -1
            var initIndex = CalculateHashFunction(value);
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