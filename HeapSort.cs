using System;

namespace SortSpace
{
    public class HeapSort
  {
      public Heap HeapObject = new Heap();

      public HeapSort(int[] array)
      {
          var depth = (int)Math.Ceiling(Math.Log(array.Length, 2.0)) - 1;
          var size = (int)Math.Pow(2, depth + 1) - 1;
          var resultArray = array;
          if(array.Length != size)
          {
              resultArray = new int[size];
              for (int i = 0; i < resultArray.Length; i++) resultArray[i] = -1;
          }
          HeapObject.MakeHeap(resultArray, depth);
          foreach (var item in array)
              HeapObject.Add(item);
      }

      public int GetNextMax()
      {
          return HeapObject.GetMax();
      }
  }

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
        if(size != a.Length) throw new Exception("Incorrect depth of heap");
        HeapArray = new int[size];
        for (int i = 0; i < HeapArray.Length; i++) HeapArray[i] = -1;
        foreach (var item in a)
        {
            if(item < 0) continue;
            Add(item);
        }
	}
		
    public int GetMax()
	{
	    // вернуть значение корня и перестроить кучу
        if(last == -1) return -1; // если куча пуста
        if(HeapArray == null || HeapArray.Length == 0) return -1;
        var top = HeapArray[0];
        //перестраиваем пирамиду
        if(last == 0)
            HeapArray[0] = -1;
        else
        {
            HeapArray[0] = HeapArray[last];
            HeapArray[last] = -1;
            SiftDown(0);
        }
        last -= 1;
        return top;
	}

    private void SiftDown(int index)
    {
        var left = 2*index+1;
        var right = 2*index+2;
        if(left >= HeapArray.Length || right >= HeapArray.Length) return;
        int current = HeapArray[left] >= HeapArray[right] ? left : right;
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
        ShiftUp(last);
		return true; 
	}

    private void ShiftUp(int index)
    {
        var parent = (index - 1) / 2;
        if(parent < 0) return;
        if(HeapArray[parent] >= HeapArray[index]) return;
        Swap(index, parent);
        ShiftUp(parent);
    }
  }
}