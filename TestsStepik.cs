using System;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class TestsStepik
    {
        [Test]
        public static void Test1()
        {
            int N = 10000000;
            var timer = new Stopwatch();

            var before = GC.GetTotalMemory(false);
            timer.Start();

            var points = new Point[N];
            /* 
            
            Это нужно делать, только если Point — класс.
            Под структуры память выделяется в момент создания массива.

            Но даже если этот цикл оставить, код со структурами будет всё равно работать заметно быстрее.
            */
            for (int i = 0; i < points.Length; i++)
                points[i] = new Point(); 
            var after = GC.GetTotalMemory(false);
            timer.Stop();

            Console.WriteLine((double)(after - before) / N);
            Console.WriteLine(timer.ElapsedMilliseconds);

            Console.WriteLine(GetMinX(1, 2, 3));
            Console.WriteLine(GetMinX(0, 3, 2));
            Console.WriteLine(GetMinX(1, -2, -3));
            Console.WriteLine(GetMinX(5, 2, 1));
            Console.WriteLine(GetMinX(4, 3, 2));
            Console.WriteLine(GetMinX(0, 4, 5));
            
            // А в этих случаях решение существует:
            Console.WriteLine(GetMinX(0, 0, 2) != "Impossible");
            Console.WriteLine(GetMinX(0, 0, 0) != "Impossible");
        }

        private static string GetMinX(int a, int b, int c)
        {
            if(a <= 0) return "Impossible";

            return (-b / (2 * a)).ToString(); // так можно вернуть строковое представление числа
        }
    }
    class Point // или class Point
    {
        public int X;
        public int Y;
    }
}