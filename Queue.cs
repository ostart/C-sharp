using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class Queue<T>
   {
      private readonly List<T> list;
      public Queue()
      {
       // инициализация внутреннего хранилища очереди
        list = new List<T>();
      } 

      public void Enqueue(T item)
      {
        list.Add(item); // вставка в хвост
      }

      public T Dequeue()
      {
        // выдача из головы
        if(Size() == 0) return default(T); // если очередь пустая
        var head = list[0];
        list.RemoveAt(0);
        return head;
      }

      public int Size()
      {
        return list.Count; // размер очереди
      }

   }
}