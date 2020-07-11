using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsDataStructures6
{
    public class Perceptron
    {
        private decimal[,] weigths;
        private decimal threshold;

        public Perceptron(decimal[,] weigths, decimal threshold)
        {
            this.weigths = weigths;
            this.threshold = threshold;
        }

        public int CalculateOutput(string filePath)
        {
            var input = GetInput(filePath);
            if (weigths.GetLength(0) != input.GetLength(0) || weigths.GetLength(1) != input.GetLength(1))
                throw new Exception("Inappropriate size of input and weigths arrays");
            
            var sum = 0m;
            for (int i = 0; i < weigths.GetLength(0); i++)
                for (int j = 0; j < weigths.GetLength(1); j++)
                    sum += weigths[i,j] * input[i,j];

            return sum < threshold ? 0 : 1;
        }

        private int[,] GetInput(string filePath)
        {
            var result = new List<int[]>();
            var allLines = File.ReadAllLines(filePath);
            foreach (var line in allLines)
            {
                var arr = new List<int>();
                 for (var i = 0; i < line.Length; i++)
                 {
                     arr.Add((int)Char.GetNumericValue(line[i]));
                 }
                 result.Add(arr.ToArray());
            }
            var length = result[0].Length;
            if (!result.All(line => line.Length == length))
                throw new Exception("Length of input strings are not same");
            
            var output = new int[result.Count, length];
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    output[i,j] = result[i][j];
                }
            }
            return output;
        }
    }
}