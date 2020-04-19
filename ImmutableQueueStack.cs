using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures5
{
    public class ImmutableQueue<T>
    {
        private Queue<T> _queue;

        public ImmutableQueue()
        {
            _queue = new Queue<T>();   
        }

        public ImmutableQueue<T> Enqueue(T value)
        {
            var newQueue = CreateNewQueue();
            newQueue._queue.Enqueue(value);
            return newQueue;
        }

        public ImmutableQueue<T> Dequeue(out T value)
        {
            var newQueue = CreateNewQueue();
            value = newQueue._queue.Dequeue();
            return newQueue;
        }

        public T Peek()
        {
            return _queue.Peek();
        }

        public int Size()
        {
            return _queue.Count;
        }

        private ImmutableQueue<T> CreateNewQueue()
        {
            var newQueue = new ImmutableQueue<T>();
            newQueue._queue = new Queue<T>(_queue.ToArray());
            return newQueue;
        }
    }

    public class ImmutableStack<T>
    {
        private Stack<T> _stack;

        public ImmutableStack()
        {
            _stack = new Stack<T>();   
        }

        public ImmutableStack<T> Push(T value)
        {
            var newStack = CreateNewStack();
            newStack._stack.Push(value);
            return newStack;
        }

        public ImmutableStack<T> Pop(out T value)
        {
            var newStack = CreateNewStack();
            value = newStack._stack.Pop();
            return newStack;
        }

        public T Peek()
        {
            return _stack.Peek();
        }

        public int Size()
        {
            return _stack.Count;
        }

        private ImmutableStack<T> CreateNewStack()
        {
            var newStack = new ImmutableStack<T>();
            var array = _stack.ToArray();
            Array.Reverse(array);
            newStack._stack = new Stack<T>(array);
            return newStack;
        }
    }
}