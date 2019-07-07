using System;

namespace AlgorithmsDataStructures
{
    public static class QueueExtra
    {
        public static void ShiftBy<T>(this Queue<T> queue, int N)
        {
            if(queue.Size() > 0)
            {
                for (int i = 0; i < N; i++)
                {
                    var head = queue.Dequeue();
                    queue.Enqueue(head);
                }
            }
        }
    }
}
