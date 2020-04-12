using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures4
{
    public class BinomialHeap
    {
        public Dictionary<int, BinomialNode> Roots {get;set;}

        public BinomialHeap()
        {
            Roots = new Dictionary<int, BinomialNode>();
        }

        public int GetMaximum()
        {
            int result = int.MinValue;
            foreach (KeyValuePair<int, BinomialNode> item in Roots)
            {
                if (item.Value.Data > result) result = item.Value.Data;
            }
            return result;
        }

        public void Add(int value)
        {
            var node = new BinomialNode(value);
            if (Roots.ContainsKey(node.Degree))
                Merge(node, Roots[node.Degree]);
            else
                Roots[node.Degree] = node;
        }

        private void Merge(BinomialNode newNode, BinomialNode rootsNode)
        {
            if (newNode.Degree != rootsNode.Degree) throw new InvalidOperationException("Forbidden to merge trees of different sizes");
            Roots.Remove(rootsNode.Degree);
            BinomialNode node;
            if (newNode.Data > rootsNode.Data) {
                node = new BinomialNode(newNode.Data, null, rootsNode, null, newNode.Degree + 1);
                rootsNode.Parent = node;
                rootsNode.RightChild = newNode.LeftChild;
                if (newNode.LeftChild != null) newNode.LeftChild.Parent = rootsNode;
            } else {
                node = new BinomialNode(rootsNode.Data, null, newNode, null, rootsNode.Degree + 1);
                newNode.Parent = node;
                newNode.RightChild = rootsNode.LeftChild;
                if (rootsNode.LeftChild != null) rootsNode.LeftChild.Parent = newNode;
            }

            if (Roots.ContainsKey(node.Degree)) {
                var currentNode = Roots[node.Degree];
                Roots.Remove(node.Degree);
                Merge(node, currentNode);
            }
            else
                Roots[node.Degree] = node;
        }
    }

    public class BinomialNode
    {
        public int Data {get;set;}
        public BinomialNode Parent {get;set;}
        public BinomialNode LeftChild {get;set;}
        public BinomialNode RightChild {get;set;}
        public int Degree {get;set;}

        public BinomialNode(int key, BinomialNode parent = null, BinomialNode left = null, BinomialNode right = null, int degree = 0)
        {
            Data = key;
            Parent = parent;
            LeftChild = left;
            RightChild = right;
            Degree = degree;
        }
    }
}