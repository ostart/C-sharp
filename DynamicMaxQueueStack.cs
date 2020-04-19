using System.Collections.Generic;

namespace AlgorithmsDataStructures5
{
    class Deque<T>
    {
        private readonly LinkedList<T> list;
        public Deque()
        {
            // инициализация внутреннего хранилища
            list = new LinkedList<T>();
        }

        public void AddFront(T item)
        {
            // добавление в голову
            list.AddFirst(item);
        }

        public void AddTail(T item)
        {
            // добавление в хвост
            list.AddLast(item);
        }

        public T RemoveFront()
        {
            // удаление из головы
            if(Size() == 0) return default(T);
            var head = list.First.Value;
            list.RemoveFirst();
            return head;
        }

        public T RemoveTail()
        {
            // удаление из хвоста
            if(Size() == 0) return default(T);
            var tail = list.Last.Value;
            list.RemoveLast();
            return tail;
        }

        public int Size()
        {
            return list.Count; // размер очереди
        }

        public T PeekFront()
        {
            return list.First.Value;
        }

        public T PeekTail()
        {
            return list.Last.Value;
        }
    }

    public class DynamicMaxQueue
    {
        private Queue<int> _queue { get;set; }
        private Deque<int> _dequeMax { get;set; }

        public DynamicMaxQueue()
        {
            _queue = new Queue<int>();
            _dequeMax = new Deque<int>();
        }

        public void Enqueue(int value)
        {
            if (_queue.Count == 0)
            {
                _queue.Enqueue(value);
                _dequeMax.AddFront(value);
                return;
            }

            var max = _dequeMax.PeekFront();
            if (value > max)
            {
                _dequeMax = new Deque<int>();
                _dequeMax.AddFront(value);
                _queue.Enqueue(value);
            }
            else
            {
                while(_dequeMax.PeekTail() < value)
                {
                    _dequeMax.RemoveTail();
                }
                _dequeMax.AddTail(value);
                _queue.Enqueue(value);
            }
        }

        public int Dequeue()
        {
            var result = _queue.Dequeue();
            var max = _dequeMax.PeekFront();
            if (result == max)
                _dequeMax.RemoveFront();
            return result;
        }

        public int Peek()
        {
            return _queue.Peek();
        }

        public int GetMax()
        {
            return _dequeMax.PeekFront();
        }
    }

    public class DynamicMaxStack
    {
        private Stack<int> _stack { get;set; }
        private Stack<int> _stackMax { get;set; }

        public DynamicMaxStack()
        {
            _stack = new Stack<int>();
            _stackMax = new Stack<int>();
        }

        public void Push(int value)
        {
            if (_stack.Count == 0)
            {
                _stack.Push(value);
                _stackMax.Push(value);
                return;
            }
            
            var max = _stackMax.Peek();
            if (value > max) 
            {
                _stack.Push(value);
                _stackMax.Push(value);
            }
            else
            {
                _stack.Push(value);
                _stackMax.Push(max);
            }
        }

        public int Pop()
        {
            _stackMax.Pop();
            return _stack.Pop();
        }

        public int Peek()
        {
            return _stack.Peek();
        }

        public int GetMax()
        {
            return _stackMax.Peek();
        }
    }
}