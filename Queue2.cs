using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

   public class Queue2<T>
   {
      private readonly Stack<T> input;
      private readonly Stack<T> output;
      public Queue2()
      {
       // инициализация внутреннего хранилища очереди
        input = new Stack<T>();
        output = new Stack<T>();
      } 

      public void Enqueue(T item)
      {
        input.Push(item); // вставка в хвост
      }

      public T Dequeue()
      {
        // выдача из головы
        if(Size() == 0) return default(T); // если очередь пустая
        return GetHead();
      }

      public int Size()
      {
        return input.Size(); // размер очереди
      }

      private T GetHead()
      {
        while(input.Size() > 0) output.Push(input.Pop());
        var head = output.Pop();
        while(output.Size() > 0) input.Push(output.Pop());
        return head;
      }

   }
}