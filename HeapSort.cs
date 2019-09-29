using System;
using System.Collections.Generic;
using AlgorithmsDataStructures2;

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
              Array.Copy(array, resultArray, array.Length);
          }
          HeapObject.MakeHeap(resultArray, depth);
      }

      public int GetNextMax()
      {
          return HeapObject.GetMax();
      }
  }
}