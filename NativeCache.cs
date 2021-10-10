namespace AlgorithmsDataStructures
{
    class NativeCache<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public int[] hits;

        public NativeCache(int cacheSize)
        {
            size = cacheSize;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            var c = value.ToCharArray();
            var total = 0;
            for (var i = 0; i <= c.GetUpperBound(0); i++)
                total += c[i];

            return total % size;
        }

        private int SeekSlot(string key)
        {
            var initIndex = HashFun(key);
            if (slots[initIndex] == null) return initIndex;
            var current = initIndex;
            do
            {
                current += 1;
                if (slots[current % size] == null) return current % size;
            } while (current % size != initIndex);

            return -1;
        }

        public void Put(string key, T value)
        {
            var index = SeekSlot(key);
            if (index != -1)
            {
                slots[index] = key;
                values[index] = value;
                return;
            }

            var minIndex = 0;
            var minVal = hits[0];
            for (int i = 0; i < size; i++)
            {
                if (hits[i] == 0)
                {
                    minIndex = i;
                    break;
                }
                if (minVal <= hits[i]) continue;
                minVal = hits[i];
                minIndex = i;
            }

            slots[minIndex] = key;
            values[minIndex] = value;
            hits[minIndex] = 0;
        }

        public T Get(string key)
        {
            var initIndex = HashFun(key);
            if (slots[initIndex] == key)
            {
                hits[initIndex] += 1;
                return values[initIndex];
            }
            var current = initIndex;
            do
            {
                current += 1;
                if (slots[current % size] == key)
                {
                    hits[current % size] += 1;
                    return values[current % size];
                }
            } while (current % size != initIndex);

            return default(T);
        }
    }
}
