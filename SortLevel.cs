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

          int iterations = CalculateNumberOfIterations(array.Length, step, i);

          var isMadeSwap = true; // для первого раза. аналог пузырькового метода
          for (int j = 0; j < iterations; j++)
          {
              if(!isMadeSwap) return;
              isMadeSwap = false;
              var l = i;
              while(l + step < array.Length)
              {
                  if(array[l] > array[l + step])
                  {
                      Swap(array, l, l + step);
                      isMadeSwap = true;
                  }       
                  l += step;
              }
          }
      }

      private static int CalculateNumberOfIterations(int arrayLength, int step, int i)
      {
          var iterations = 0;
          var k = i;
          while(k + step < arrayLength)
          {
              iterations += 1;
              k += step;
          }
          return iterations;
      }

      public static List<int> KnuthSequence(int array_size)
      {
          var result = new List<int>();
          var i = 0;
          while(CalculateKnuthNumber(i) <= array_size)
          {
              result.Add(CalculateKnuthNumber(i));
              i += 1;
          }
          result.Reverse();
          return result;
      }

      private static int CalculateKnuthNumber(int i)
      {
          if(i == 0) return 1;
          return 3 * CalculateKnuthNumber(i-1) + 1;
      }

      public static void ShellSort(int[] array)
      {
          var knuthSequence = KnuthSequence(array.Length);
          foreach (var knuthNumber in knuthSequence)
          {
              for (int i = 0; i < knuthNumber; i++)
              {
                  var step = knuthNumber == 1 ? knuthNumber : knuthNumber - 1;
                  InsertionSortStep(array, step, i);
              }
          }
      }

      public static int ArrayChunk(int[] M)
      {
          var referenceValueIndex = M.Length / 2;
          var N = M[referenceValueIndex];
          var i1 = 0;
          var i2 = M.Length - 1;
          for (;;)
          {
            if(i1 == i2 || (i1 == i2 - 1 && M[i1] < M[i2]))
                return referenceValueIndex;
            if(i1 == i2 - 1 && M[i1] > M[i2])
            {
                Swap(M, i1, i2);
                return ArrayChunk(M);
            }
            if(M[i1] >= N && M[i2] <= N)
            {
                Swap(M, i1, i2);
                if(i1 == referenceValueIndex || i2 == referenceValueIndex) // перенайти опорный, т.к. после свапа получит другой индекс
                    referenceValueIndex = Array.FindIndex(M, item => item == N);
            }
                
            if(M[i1] < N) i1 += 1;
            if(M[i2] > N) i2 -= 1;
          } 
      }

      public static int ArrayChunk(int[] M, int left, int right)
      {
          var referenceValueIndex = left + ((right - left + 1) / 2);
          var N = M[referenceValueIndex];
          var i1 = left;
          var i2 = right;
          for (;;)
          {
            if(i1 == i2 || (i1 == i2 - 1 && M[i1] < M[i2]))
                return referenceValueIndex;
            if(i1 == i2 - 1 && M[i1] > M[i2])
            {
                Swap(M, i1, i2);
                return ArrayChunk(M, left, right);
            }
            if(M[i1] >= N && M[i2] <= N)
            {
                Swap(M, i1, i2);
                if(i1 == referenceValueIndex || i2 == referenceValueIndex) //перенайти опорный, т.к. после свапа получит другой индекс
                    referenceValueIndex = Array.FindIndex(M, item => item == N); //это корректно только для неповторяющихся значений в массиве
            }
                
            if(M[i1] < N) i1 += 1;
            if(M[i2] > N) i2 -= 1;
          } 
      }

      public static void QuickSort(int[] array, int left, int right)
      {
          if(left >= right) return;

          var N = ArrayChunk(array, left, right); //referenceValueIndex

          QuickSort(array, left, N-1);
          QuickSort(array, N+1, right);
      }

      public static void QuickSortTailOptimization(int[] array, int left, int right)
      {
        while (left < right) 
        {
            int pivot = ArrayChunk(array, left, right);
            QuickSortTailOptimization(array, left, pivot - 1);
            left = pivot + 1;
        } 
      }
    }
}