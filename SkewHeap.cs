using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures4
{
    public class SkewHeap
    {
        public SkewNode Root { get;set; }

        public SkewHeap(SkewNode initials = null)
        {
            Root = initials;  
        }

        public SkewNode Merge(SkewNode k1, SkewNode k2)
        {
            if (k1 == null && k2 == null) return null;
            if (k1 == null) return k2;
            if (k2 == null) return k1;
            if (k1.Value > k2.Value) return Merge(k2, k1);
            var left = k1.LeftChild;
            var right = k1.RightChild;
            k1.LeftChild = right;
            k1.RightChild = left;
            k1.LeftChild = Merge(k2, k1.LeftChild);
            return k1;
        }

        public void Add(int value)
        {
            var node = new SkewNode(value);
            Root = Merge(Root, node);
        }

        public void Remove()
        {
            Root = Merge(Root.LeftChild, Root.RightChild);
        }
    }

    public class SkewNode
    {
        public int Value {get;set;}
        public SkewNode LeftChild {get;set;}
        public SkewNode RightChild {get;set;}

        public SkewNode(int value, SkewNode left = null, SkewNode right = null)
        {
            Value = value;
            LeftChild = left;
            RightChild = right;
        }
    }
}