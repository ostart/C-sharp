using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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
                _LeafBindingStructure.Add(descLeafs[i], new List<BWTNode>());
                _LeafBindingStructure.Add(ascLeafs[i], new List<BWTNode>());
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
                if (i == _levels) WriteChildColors(nodesInLine);
                WriteIndexes(nodesInLine);
                WriteParentColors(nodesInLine);
            }
            //Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, name);
            //Console.WriteLine(name);
        }

        private void WriteChildColors(List<BWTNode> nodesInLine)
        {
            throw new NotImplementedException();
        }

        private void WriteIndexes(List<BWTNode> nodesInLine)
        {
            var indexes = nodesInLine.Select(x => x.Index).ToList();
            var str = string.Join(" ", indexes);
            Console.WriteLine($" {str} ");
        }

        private void WriteParentColors(List<BWTNode> nodesInLine)
        {
            throw new NotImplementedException();
        }

        private void ColorizeLeafs(List<BWTNode> descLeafs, List<BWTNode> ascLeafs)
        {
            foreach (var descLeaf in descLeafs)
            {
                var relatedNodes = _LeafBindingStructure[descLeaf];
                descLeaf.LeftChild = relatedNodes[0];
                descLeaf.LeftChildColor = relatedNodes[0].ParentColor;
                descLeaf.RightChild = relatedNodes[1];
                descLeaf.RightChildColor = relatedNodes[1].ParentColor;
            }
            foreach (var ascLeaf in ascLeafs)
            {
                var relatedNodes = _LeafBindingStructure[ascLeaf];
                ascLeaf.LeftChild = relatedNodes[0];
                ascLeaf.LeftChildColor = relatedNodes[0].ParentColor;
                ascLeaf.RightChild = relatedNodes[1];
                ascLeaf.RightChildColor = relatedNodes[1].ParentColor;
            }
        }

        private void BindLeafs(List<BWTNode> descLeafs, List<BWTNode> ascLeafs)
        {
            var sortedByPossibility = SortAscendingByPossibilityOfBind(descLeafs, ascLeafs);
            foreach (var node in sortedByPossibility)
            {
                if (_LeafBindingStructure[node].Count == 2) continue;
                if (descLeafs.Contains(node, new BWTNodeComparer()))
                {
                    foreach (var possibleLinkedNode in ascLeafs)
                    {
                        if (_LeafBindingStructure[possibleLinkedNode].Count == 2) continue;
                        if (node.ParentColor != possibleLinkedNode.ParentColor)
                        {
                            if (_LeafBindingStructure[node].Count == 0 || (_LeafBindingStructure[node].Count == 1 && _LeafBindingStructure[node][0].ParentColor != possibleLinkedNode.ParentColor))
                            {
                                _LeafBindingStructure[node].Add(possibleLinkedNode);
                                _LeafBindingStructure[possibleLinkedNode].Add(node);
                            }
                        }
                    }
                }
                else // ascLeafs
                {
                    foreach (var possibleLinkedNode in descLeafs)
                    {
                        if (_LeafBindingStructure[possibleLinkedNode].Count == 2) continue;
                        if (node.ParentColor != possibleLinkedNode.ParentColor)
                        {
                            if (_LeafBindingStructure[node].Count == 0 || (_LeafBindingStructure[node].Count == 1 && _LeafBindingStructure[node][0].ParentColor != possibleLinkedNode.ParentColor))
                            {
                                _LeafBindingStructure[node].Add(possibleLinkedNode);
                                _LeafBindingStructure[possibleLinkedNode].Add(node);
                            }
                        }
                    }
                }
            }
        }

        private List<BWTNode> SortAscendingByPossibilityOfBind(List<BWTNode> descLeafs, List<BWTNode> ascLeafs)
        {
            var resultDico = new Dictionary<BWTNode, int>();
            foreach (var leaf in descLeafs)
            {
                var counter = 0;
                foreach (var leaf2 in ascLeafs)
                {
                    if (leaf.ParentColor != leaf2.ParentColor) counter += 1;
                }
                resultDico.Add(leaf, counter);
            }
            foreach (var leaf in ascLeafs)
            {
                var counter = 0;
                foreach (var leaf2 in descLeafs)
                {
                    if (leaf.ParentColor != leaf2.ParentColor) counter += 1;
                }
                resultDico.Add(leaf, counter);
            }

            var resultList = resultDico.ToList();
            resultList.Sort((pair1,pair2) => pair1.Value.CompareTo(pair2.Value));
            return resultList.Select(pair => pair.Key).ToList();
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

            var usedColors = new List<int> {node.ParentColor};
            var freeColors = _colors.Except(usedColors).ToList();
            node.LeftChildColor = freeColors[0];
            node.LeftChild.ParentColor = freeColors[0];
            usedColors.Add(freeColors[0]);
            freeColors = _colors.Except(usedColors).ToList();
            node.RightChildColor = freeColors[0];
            node.RightChild.ParentColor = freeColors[0];
            Colorize(node.LeftChild);
            Colorize(node.RightChild);
        }

        private BWTNode GenerateNode(int? parentIndex, BWTNode parentNode, bool isRight, int level, bool isDescending, int shift = 0)
        {
            if(parentIndex == null)
            {
                var root = new BWTNode(0, null, 0, shift);
                if (isDescending) DescendingTree[0] = root;
                else AscendingTree[0] = root;
                root.ParentColor = 1;
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

    public class BWTNodeComparer : IEqualityComparer<BWTNode>
    {
        public bool Equals([AllowNull] BWTNode x, [AllowNull] BWTNode y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;
            return x.Index == y.Index && x.Level == y.Level;
        }

        public int GetHashCode([DisallowNull] BWTNode obj)
        {
            return obj.Index.GetHashCode() ^ obj.Level.GetHashCode();
        }
    }
}