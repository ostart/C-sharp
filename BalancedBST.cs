using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
	public static class BalancedBST
	{
		public static int[] GenerateBBSTArray(int[] a) 
		{  
			Array.Sort(a);
            var result = new int[a.Length];
            ParseArray(a, result, -1, true);
            return result;
		}

        private static void ParseArray(int[] inputArray, int[] result, int parentIndex, bool isRight)
        {
            var center = inputArray.Length / 2;
            var currentIndex = isRight ? (2*parentIndex + 2) : (2*parentIndex + 1);
            result[currentIndex] = inputArray[center];
            if (center == 0) return;
            var left = new int[center];
            var right = new int[center];
            Array.Copy(inputArray, left, center);
            Array.Copy(inputArray, center + 1, right, 0, center);
            ParseArray(left, result, currentIndex, false);
            ParseArray(right, result, currentIndex, true);
        }
    }
}  