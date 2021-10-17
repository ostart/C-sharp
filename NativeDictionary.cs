namespace AlgorithmsDataStructures
{

    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            // всегда возвращает корректный индекс слота
            var total = 0;
            var c = key.ToCharArray();
            for (var i = 0; i <= c.GetUpperBound(0); i++)
                total += (int)c[i];

            return total % size;
        }

        public bool IsKey(string key)
        {
            var index = HashFun(key);
            return slots[index] == key;
        }

        public void Put(string key, T value)
        {
            // гарантированно записываем 
            // значение value по ключу key
            var index = HashFun(key);
            slots[index] = key;
            values[index] = value;
        }

        public T Get(string key)
        {
            var index = HashFun(key);
            return slots[index] == key ? values[index] : default(T);
        }
    }
}
