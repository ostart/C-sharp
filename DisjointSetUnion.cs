using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures4
{
    public class DSU<T>
    {
        private readonly Dictionary<T, T> _parent;
        private readonly Dictionary<T, int> _rank; // Ранг дерева >= высоты дерева
        private readonly Random _rand;

        public DSU()
        {
            _parent = new Dictionary<T, T>();
            _rank = new Dictionary<T, int>();
            _rand = new Random();
        }

        public void MakeSet(T node)
        {
            _parent.Add(node, node);
            _rank.Add(node, 0);
        }

        public T Find(T value)
        {
            if (_parent[value].Equals(value))
            {
                return value;
            }

            var topParent = SearchTopParent(value);

            ChangeTreeParent(value, topParent);

            return topParent;
        }

        public void Unite(T first, T second, bool isRandom = true)
        {
            first = Find(first);
            second = Find(second);

            if (first.Equals(second)) return;

            if (isRandom)
            {
                if (_rand.Next() % 2 == 0)
                    _parent[first] = second;
                else
                    _parent[second] = first;
            }
            else
            {
                if (_rank[first] < _rank[second])
                    _parent[first] = second;
                else
                {
                    _parent[second] = first;
                    if (_rank[first] == _rank[second])
                        ++_rank[first];
                }
            }
        }

        private T SearchTopParent(T startIndex)
        {
            var topParent = _parent[startIndex];

            while (!_parent[topParent].Equals(topParent))
            {
                topParent = _parent[topParent];
            }

            return topParent;
        }

        private void ChangeTreeParent(T index, T maxParent)
        {
            while (!_parent[index].Equals(maxParent))
            {
                var nextIndex = _parent[index];
                _parent[index] = maxParent;
                index = nextIndex;
            }
        }
    }
}