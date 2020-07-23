using System;
using System.Linq;
using System.Collections.Generic;

namespace AlgorithmsDataStructures6
{
    public class BWT
    {
        public BWTNode RootOfDescendingTree {get;set;}
        public List<BWTNode> DescendingTree {get;set;}
        public BWTNode RootOfAscendingTree {get;set;}
        public List<BWTNode> AscendingTree {get;set;}
        private Dictionary<BWTNode, List<BWTNode>> _LeafBindingStructure {get;set;}
        
        private int _levels;
        private List<int> _colors;

        public BWT(int levels, int colors, bool isSymmetric)
        {
            if (colors < 4) throw new InvalidOperationException("Need more than 3 colors");
            _levels = levels;
            _colors = Enumerable.Range(1, colors).ToList();
            DescendingTree = new List<BWTNode>();
            AscendingTree = new List<BWTNode>();
            for (int i = 0; i < (int)Math.Pow(2, levels + 1) - 1; i++)
            {
                DescendingTree.Add(null);
                AscendingTree.Add(null);
            }

            RootOfDescendingTree = GenerateNode(null, null, false, 0, true);
            Colorize(RootOfDescendingTree);
            var shift = (int)Math.Pow(2, levels + 1) - 1;
            RootOfAscendingTree = GenerateNode(null, null, false, 0, false, shift);
            if (isSymmetric) Colorize(DescendingTree, AscendingTree);
            else Colorize(RootOfAscendingTree);

            var leafsNumber = (int)Math.Pow(2, levels);
            var descLeafs = DescendingTree.GetRange(DescendingTree.Count - leafsNumber, leafsNumber);
            var ascLeafs = AscendingTree.GetRange(AscendingTree.Count - leafsNumber, leafsNumber);
            _LeafBindingStructure = new Dictionary<BWTNode, List<BWTNode>>();
            for (int i = 0; i < descLeafs.Count; i++)
            {
                _LeafBindingStructure.Add(descLeafs[i], new List<BWTNode> {null, null});
                _LeafBindingStructure.Add(ascLeafs[i], new List<BWTNode> {null, null});
            }
            BindLeafs(descLeafs,ascLeafs);
            ColorizeLeafs(descLeafs, ascLeafs);
        }

        public void ConsoleWriteLines()
        {
            var shift = 0;
            for (int i = 0; i <= _levels; i++)
            {
                var nodesNumber = (int)Math.Pow(2, i);
                var nodesInLine = DescendingTree.GetRange(shift, nodesNumber);
                shift += nodesNumber;
                WriteParentColors(nodesInLine);
                WriteIndexes(nodesInLine);
                if (i == _levels) WriteChildColors(nodesInLine);
            }

            for (int i = _levels; i >= 0; i--)
            {
                var nodesNumber = (int)Math.Pow(2, i);
                shift -= nodesNumber;
                var nodesInLine = AscendingTree.GetRange(shift, nodesNumber);
                if (i == _levels) WriteChildColors(nodesInLine, true);
                WriteIndexes(nodesInLine, true);
                WriteParentColors(nodesInLine, true);
            }
        }

        private void WriteChildColors(List<BWTNode> nodesInLine, bool isUpward = false)
        {
            if (isUpward)
            {
                for (var i = nodesInLine.Count - 1; i >= 0; i--)
                {
                    var node = nodesInLine[i];
                    Console.ForegroundColor = (ConsoleColor)node.RightChildColor;
                    Console.Write(" |");
                    Console.ForegroundColor = (ConsoleColor)node.LeftChildColor;
                    Console.Write(" |");
                }
            }
            else
            {
                foreach (var node in nodesInLine)
                {
                    Console.ForegroundColor = (ConsoleColor)node.LeftChildColor;
                    Console.Write(" |");
                    Console.ForegroundColor = (ConsoleColor)node.RightChildColor;
                    Console.Write(" |");
                }
            }

            Console.ResetColor();
            Console.WriteLine(" ");
        }

        private void WriteIndexes(List<BWTNode> nodesInLine, bool isUpward = false)
        {
            var indexes = nodesInLine.Select(x => x.Index).ToList();
            if (isUpward) indexes.Reverse();
            var str = string.Join(" ", indexes);
            Console.WriteLine($" {str} ");
        }

        private void WriteParentColors(List<BWTNode> nodesInLine, bool isUpward = false)
        {
            if (isUpward)
            {
                for (var i = nodesInLine.Count - 1; i >= 0; i--)
                {
                    var node = nodesInLine[i];
                    Console.ForegroundColor = (ConsoleColor)node.ParentColor;
                    Console.Write(" |");
                }
            }
            else
            {
                foreach (var node in nodesInLine)
                {
                    Console.ForegroundColor = (ConsoleColor)node.ParentColor;
                    Console.Write(" |");
                }
            }
            
            Console.ResetColor();
            Console.WriteLine(" ");
        }

        private void ColorizeLeafs(List<BWTNode> descLeafs, List<BWTNode> ascLeafs)
        {
            var index = GetLeftColorIndexForLevel(descLeafs[0].Level);

            foreach (var descLeaf in descLeafs)
            {
                var relatedNodes = _LeafBindingStructure[descLeaf];
                descLeaf.LeftChild = relatedNodes[0];
                descLeaf.LeftChildColor = _colors[index];
                descLeaf.RightChild = relatedNodes[1];
                descLeaf.RightChildColor = _colors[index + 1];
            }
            foreach (var ascLeaf in ascLeafs)
            {
                var relatedNodes = _LeafBindingStructure[ascLeaf];
                ascLeaf.LeftChild = relatedNodes[0];
                ascLeaf.LeftChildColor = _colors[index];
                ascLeaf.RightChild = relatedNodes[1];
                ascLeaf.RightChildColor = _colors[index + 1];
            }
        }

        private void BindLeafs(List<BWTNode> descLeafs, List<BWTNode> ascLeafs)
        {
            foreach (var node in descLeafs)
            {
                if (_LeafBindingStructure[node][0] != null && _LeafBindingStructure[node][1] != null) continue;

                foreach (var possibleLinkedNode in ascLeafs)
                {
                    if (_LeafBindingStructure[node][0] == null && _LeafBindingStructure[possibleLinkedNode][0] == null)
                    {
                        _LeafBindingStructure[node][0] = possibleLinkedNode;
                        _LeafBindingStructure[possibleLinkedNode][0] = node;
                        continue;
                    }
                    if (_LeafBindingStructure[node][1] == null && _LeafBindingStructure[possibleLinkedNode][1] == null)
                    {
                        _LeafBindingStructure[node][1] = possibleLinkedNode;
                        _LeafBindingStructure[possibleLinkedNode][1] = node;
                        continue;
                    }
                }
            }

            foreach (var node in ascLeafs)
            {
                if (_LeafBindingStructure[node][0] != null && _LeafBindingStructure[node][1] != null) continue;

                foreach (var possibleLinkedNode in descLeafs)
                {
                    if (_LeafBindingStructure[node][0] == null && _LeafBindingStructure[possibleLinkedNode][0] == null)
                    {
                        _LeafBindingStructure[node][0] = possibleLinkedNode;
                        _LeafBindingStructure[possibleLinkedNode][0] = node;
                        continue;
                    }
                    if (_LeafBindingStructure[node][1] == null && _LeafBindingStructure[possibleLinkedNode][1] == null)
                    {
                        _LeafBindingStructure[node][1] = possibleLinkedNode;
                        _LeafBindingStructure[possibleLinkedNode][1] = node;
                        continue;
                    }
                }
            }
        }

        private void Colorize(List<BWTNode> descendingTree, List<BWTNode> ascendingTree)
        {
            var colorList = descendingTree.Select(x => x.ParentColor).ToList();
            var ascendingParentColors = new List<int>();
            var shift = 0;
            for (int i = 0; i <= _levels; i++)
            {
                var count = (int)Math.Pow(2, i);
                var elements = colorList.GetRange(shift, count);
                shift += count;
                elements.Reverse();
                foreach (var elem in elements)    
                    ascendingParentColors.Add(elem);
            }
            for (int i = 0; i < ascendingParentColors.Count; i++)
            {
                ascendingTree[i].ParentColor = ascendingParentColors[i];
                if (i == 0) continue;
                if (i % 2 == 0) //right
                {
                    var index = (i - 2) / 2;
                    ascendingTree[index].RightChildColor = ascendingParentColors[i];
                }
                else //left
                {
                    var index = (i - 1) / 2;
                    ascendingTree[index].LeftChildColor = ascendingParentColors[i];
                }
            }
        }

        private void Colorize(BWTNode node)
        {
            if (node.LeftChild == null && node.RightChild == null) return;

            var index = GetLeftColorIndexForLevel(node.Level);

            node.LeftChildColor = _colors[index];
            node.LeftChild.ParentColor = _colors[index];
            node.RightChildColor = _colors[index + 1];
            node.RightChild.ParentColor = _colors[index + 1];
            Colorize(node.LeftChild);
            Colorize(node.RightChild);
        }

        private int GetLeftColorIndexForLevel(int level)
        {
            var baseColors = _colors.Count;
            if (_colors.Count % 2 == 1) baseColors -= 1;
            var index = (level * 2) % baseColors;
            return index;
        }

        private BWTNode GenerateNode(int? parentIndex, BWTNode parentNode, bool isRight, int level, bool isDescending, int shift = 0)
        {
            if(parentIndex == null)
            {
                var root = new BWTNode(0, null, 0, shift);
                if (isDescending) DescendingTree[0] = root;
                else AscendingTree[0] = root;
                root.ParentColor = 0;
                root.LeftChild = GenerateNode(0, root, false, level+1, isDescending, shift);
                root.RightChild = GenerateNode(0, root, true, level+1, isDescending, shift);
                return root;
            }

            if(level > _levels) return null;

            var currentIndex = isRight ? 2*(int)parentIndex + 2 : 2*(int)parentIndex + 1; 
            var node = new BWTNode(currentIndex, parentNode, level, shift);
            if (isDescending) DescendingTree[currentIndex] = node;
            else AscendingTree[currentIndex] = node;
            node.LeftChild = GenerateNode(currentIndex, node, false, level+1, isDescending, shift);
            node.RightChild = GenerateNode(currentIndex, node, true, level+1, isDescending, shift);
            return node;
        }
    }

    public class BWTNode
    {
        public int Index {get;set;}
        public int Level {get;set;}

        public BWTNode Parent {get;set;}
        public int ParentColor {get;set;}

        public BWTNode LeftChild {get;set;}
        public int LeftChildColor {get;set;}

        public BWTNode RightChild {get;set;}
        public int RightChildColor {get;set;}

        public BWTNode(int index, BWTNode parent, int level, int shift)
        {
            Index = index + shift + 1;
            Parent = parent;
            Level = level;
        }
    }
}