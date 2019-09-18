using System;
using System.Collections.Generic;

namespace SortSpace
{
  public static class SortLevel
  {
      public static void SelectionSortStep(int[] array, int i)
      {
          var minIndex = GetIndexOfMin(array, i+1);
          Swap(array, i, minIndex);
      }
      
      private static int GetIndexOfMin(int[] array, int startIndex)
      {
          var minValue = array[startIndex];
          var minIndex = startIndex;
          for (int i = startIndex + 1; i < array.Length; i++)
          {
              if(array[i] < minValue)
              {
                  minValue = array[i];
                  minIndex = i;
              }
          }
          return minIndex;
      }

      private static void Swap(int[] array, int i, int k)
      {
          var iValue = array[i];
          var kValue = array[k];
          array[i] = kValue;
          array[k] = iValue;
      }
      
      public static bool BubbleSortStep(int[] array)
      {
          var flag = true;
          for (int i = 1; i < array.Length; i++)
          {
              if(array[i-1] > array[i])
              {
                  Swap(array, i-1, i);
                  flag = false;
              }
          }
          return flag;
      }

      public static void InsertionSortStep(int[] array, int step, int i)
      {
          if(i + step >= array.Length) return;
          var iterations = 0;
          var k = i;
          while(k + step < array.Length)
          {
              iterations += 1;
              k += step;
          }
          for (int j = 0; j < iterations; j++)
          {
            var l = i;
            while(l + step < array.Length)
            {
                if(array[l] > array[l + step])
                    Swap(array, l, l + step);
                l += step;
            }
          }
      }
  }
}