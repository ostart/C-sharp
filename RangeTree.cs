using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures4
{
    public class RangeTree
    {
        public RangeTreeNode Root = null;

        public List<Point> sortedX = null;

        public RangeTree(List<Point> points)
        {
            sortedX = points.OrderBy(x => x.X).ToList();
            var basicNodes = new List<RangeTreeNode>();
            foreach (var point in sortedX)
            {
                basicNodes.Add(new RangeTreeNode(point, point.X, new List<int> {point.Y}));
            }
            Root = CreateUpwardNode(basicNodes);
        } 

        public List<Point> GetPoints(int minX, int maxX, int minY, int maxY)
        {
            var result = new List<Point>();
            GetPoints(Root, result, minX, maxX, minY, maxY);
            return result;
        }

        private void GetPoints(RangeTreeNode node, List<Point> result, int minX, int maxX, int minY, int maxY)
        {
            if (node.LeftChild == null && node.RightChild == null)
            {
                if (node.Value >= minX && node.Value <= maxX && SatisfySecondDimention(node.SecondDimension, minY, maxY))
                    result.Add(node.Node);
            }
            if (node.Value < minX)
            {
                if (node.RightChild != null) GetPoints(node.RightChild, result, minX, maxX, minY, maxY);
                return;
            }
            if (node.Value > maxX)
            {
                if (node.LeftChild != null) GetPoints(node.LeftChild, result, minX, maxX, minY, maxY);
                return;
            }
            if (!SatisfySecondDimention(node.SecondDimension, minY, maxY)) return;
            if (node.LeftChild != null) GetPoints(node.LeftChild, result, minX, maxX, minY, maxY);
            if (node.RightChild != null) GetPoints(node.RightChild, result, minX, maxX, minY, maxY);
        }

        private bool SatisfySecondDimention(List<int> secondDimension, int minY, int maxY)
        {
            return secondDimension.Any(i => i >= minY && i <= maxY);
        }

        private static RangeTreeNode CreateUpwardNode(List<RangeTreeNode> nodes)
        {
            if (nodes.Count == 2)
            {
                var value = GetMaxValueLeft(nodes[0]);
                var second = new List<int>();
                second.AddRange(nodes[0].SecondDimension);
                second.AddRange(nodes[1].SecondDimension);
                var root = new RangeTreeNode(null, value, second.OrderBy(x => x).ToList(), nodes[0], nodes[1]);
                nodes[0].Parent = root;
                nodes[1].Parent = root;
                return root;
            }

            var newNodes = new List<RangeTreeNode>();
            for (int i = 0; i < nodes.Count / 2; i++)
            {
                var value = GetMaxValueLeft(nodes[2*i]);
                var second = new List<int>();
                second.AddRange(nodes[2*i].SecondDimension);
                second.AddRange(nodes[2*i+1].SecondDimension);
                var node = new RangeTreeNode(null, value, second.OrderBy(x => x).ToList(), nodes[2*i], nodes[2*i+1]);
                nodes[2*i].Parent = node;
                nodes[2*i+1].Parent = node;
                newNodes.Add(node);
            }
            
            if (nodes.Count % 2 == 1)
                newNodes.Add(nodes[nodes.Count - 1]);

            return CreateUpwardNode(newNodes);
        }

        private static int GetMaxValueLeft(RangeTreeNode node)
        {
            if (node.RightChild == null) return node.Value;
            return GetMaxValueLeft(node.RightChild);
        }
    }

    public class RangeTreeNode
    {
        public RangeTreeNode(Point point, int value, List<int> second, RangeTreeNode left = null, RangeTreeNode right = null, RangeTreeNode parent = null)
        {
            Node = point;
            Value = value;
            Parent = parent;
            LeftChild = left;
            RightChild = right;
            SecondDimension = second;
        }

        public int Value {get;set;}
        public Point Node {get;set;}
        public RangeTreeNode Parent {get;set;}
        public RangeTreeNode LeftChild {get;set;}
        public RangeTreeNode RightChild {get;set;}

        public List<int> SecondDimension {get;set;}
    }

    public class Point
    {
        public int X {get;set;}
        public int Y {get;set;}

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
