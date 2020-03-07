using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures4
{
    public class RmqLca
    {
        private readonly int[] _array;
        private readonly Func<int[], int, int, int> _func;

        public RmsNode Root = null;

        public RmqLca(int[] array, Func<int[], int, int, int> func)
        {
            _array = array;
            _func = func;
        }

        public void FormTreeTopDown()
        {
            Root = CreateTopDownNode(0, _array.Length - 1, null);
        }

        private RmsNode CreateTopDownNode(int startIndex, int stopIndex, RmsNode parent)
        {
            if (startIndex == stopIndex) 
            {
                return new RmsNode(_array[startIndex], startIndex, stopIndex, parent);
            }
            var value = _func(_array, startIndex, stopIndex);
            var node = new RmsNode(value, startIndex, stopIndex, parent);
            var centralIndex = (startIndex + stopIndex) / 2;
            node.LeftChild = CreateTopDownNode(startIndex, centralIndex, node);
            node.RightChild = CreateTopDownNode(centralIndex + 1, stopIndex, node);
            return node;
        }

        public void FormTreeUpward()
        {
            var basicNodes = new List<RmsNode>();
            for (int i = 0; i < _array.Length; i++)
            {
                basicNodes.Add(new RmsNode(_array[i], i, i, null));
            }
            Root = CreateUpwardNode(basicNodes);
        }

        private RmsNode CreateUpwardNode(List<RmsNode> nodes)
        {
            if (nodes.Count == 2)
            {
                var value = nodes[0].Value <= nodes[1].Value ? nodes[0].Value : nodes[1].Value;
                var root = new RmsNode(value, nodes[0].LeftIndex, nodes[1].RightIndex, null);
                root.LeftChild = nodes[0];
                root.RightChild = nodes[1];
                nodes[0].Parent = root;
                nodes[1].Parent = root;
                return root;
            }

            var newNodes = new List<RmsNode>();
            for (int i = 0; i < nodes.Count / 2; i++)
            {
                var value = nodes[2*i].Value <= nodes[2*i+1].Value ? nodes[2*i].Value : nodes[2*i+1].Value;
                var node = new RmsNode(value, nodes[2*i].LeftIndex, nodes[2*i+1].RightIndex, null);
                node.LeftChild = nodes[2*i];
                node.RightChild = nodes[2*i+1];
                nodes[2*i].Parent = node;
                nodes[2*i+1].Parent = node;
                newNodes.Add(node);
            }
            
            if (nodes.Count % 2 == 1)
                newNodes.Add(nodes[nodes.Count - 1]);

            return CreateUpwardNode(newNodes);
        }

        public int FindFuncValue(int i, int j, RmsNode node = null)
        {
            if (Root == null) throw new Exception("Tree is not initialized");
            if (node == null) node = Root;
            if (node.LeftIndex == i && node.RightIndex == j) return node.Value;
            if (node.LeftChild.LeftIndex <= i && node.LeftChild.RightIndex >= j) return FindFuncValue(i, j, node.LeftChild);
            if (node.RightChild.LeftIndex <= i && node.RightChild.RightIndex >= j) return FindFuncValue(i, j, node.RightChild);
            var left = FindFuncValue(i, node.LeftChild.RightIndex, node.LeftChild);
            var right = FindFuncValue(node.RightChild.LeftIndex, j, node.RightChild);
            return left <= right ? left : right;
        }
    }

    public class RmsNode
    {
        public int Value;
        public int LeftIndex;
        public int RightIndex;

        public RmsNode Parent;
        public RmsNode LeftChild;
        public RmsNode RightChild;

        public RmsNode(int value, int leftIndex, int rightIndex, RmsNode parent)
        {
            Value = value;
            LeftIndex = leftIndex;
            RightIndex = rightIndex;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }
}
