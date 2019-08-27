using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
	public class Heap
	{
		public int [] HeapArray; // хранит неотрицательные числа-ключи
        private int last = -1;
		
		public Heap() { HeapArray = null; last = -1; }
		
		public void MakeHeap(int[] a, int depth)
		{
			// создаём массив кучи HeapArray из заданного
            // размер массива выбираем на основе глубины depth
			var size = (int)Math.Pow(2, depth + 1) - 1;
            if(size < a.Length) throw new Exception("Incorrect depth of heap");
            HeapArray = new int[size];
            foreach (var item in a)
            {
                Add(item);
            }
		}
		
        public int GetMax()
		{
			// вернуть значение корня и перестроить кучу
            if(last == -1) return -1; // если куча пуста
            var result = HeapArray[0];
            //TODO перестраиваем пирамиду
            if(last == 0)
                HeapArray = null;
            else
            {
                HeapArray[0] = HeapArray[last];
                HeapArray[last] = 0;
                SiftDown(0);
            }
            last -= 1;
            return result;
		}

        private void SiftDown(int index)
        {
            var left = 2*index+1;
            var right = 2*index+2;
            int current;
            if(HeapArray[left] >= HeapArray[right])
                current = left;
            else
                current = right;
            if(HeapArray[index] >= HeapArray[current]) return;
            Swap(index, current);
            SiftDown(current);
        }

        private void Swap(int index, int current)
        {
            var temp = HeapArray[index];
            HeapArray[index] = HeapArray[current];
            HeapArray[current] = temp;
        }

        public bool Add(int key)
		{
			// добавляем новый элемент key в кучу и перестраиваем её
            last += 1;
            if(last >= HeapArray.Length) return false;// если куча вся заполнена
            HeapArray[last] = key;
            SiftUp(last);
			return true; 
		}

        private void SiftUp(int index)
        {
            var parent = (index - 1) / 2;
            if(HeapArray[parent] >= HeapArray[index]) return;
            Swap(index, parent);
            SiftUp(parent);
        }
    }
}