using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures4
{
    public class Treap
    {
        public TreapNode Root { get;set; }
        public Treap(List<int[]> array)
        {
            array.Sort((item1, item2) => item1[0].CompareTo(item2[0]));
            Root = MakeTreap(array, null);
        }

        private TreapNode MakeTreap(List<int[]> array, TreapNode parent)
        {
            if (array.Count == 0) return null;
            if (array.Count == 1)
            {
                var leafKey = array[0][0];
                var leafPriority = array[0][1];
                return new TreapNode(leafKey, leafPriority, parent);
            }

            var MaxPriority = array.Max(item => item[1]);
            var indexOfMaxPriority = array.FindIndex(item => item[1] == MaxPriority);
            var key = array[indexOfMaxPriority][0];
            var priority = array[indexOfMaxPriority][1];
            var node = new TreapNode(key, priority, parent);
            node.LeftChild = MakeTreap(array.GetRange(0, indexOfMaxPriority), node);
            node.RightChild = MakeTreap(array.GetRange(indexOfMaxPriority + 1, array.Count - indexOfMaxPriority - 1), node);
            return node;
        }
    }

    public class TreapNode
    {
        public int Key { get;set; }
        public int Priority { get;set; }
        public TreapNode Parent { get;set; }
        public TreapNode LeftChild { get;set; }
        public TreapNode RightChild { get;set; }
        public TreapNode (int key, int priority, TreapNode parent = null, TreapNode left = null, TreapNode right = null)
        {
            Key = key;
            Priority = priority;
            Parent = parent;
            LeftChild = left;
            RightChild = right;
        }
    }
}