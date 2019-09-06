using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue; // значение в узле
        public SimpleTreeNode<T> Parent; // родитель или null для корня
        public List<SimpleTreeNode<T>> Children; // список дочерних узлов или null
        public int Level; // уровень узла

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
        }
    }

    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root; // корень, может быть null

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }

        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            // ваш код добавления нового дочернего узла существующему ParentNode
            NewChild.Parent = ParentNode;
            if (ParentNode.Children == null)
                ParentNode.Children = new List<SimpleTreeNode<T>>();
            ParentNode.Children.Add(NewChild);
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            // ваш код удаления существующего узла NodeToDelete
            NodeToDelete.Parent.Children.Remove(NodeToDelete);
            if(NodeToDelete.Parent.Children.Count == 0) NodeToDelete.Parent.Children = null;
            if(NodeToDelete.Children != null)
            {
                foreach(var item in NodeToDelete.Children)
                    item.Parent = NodeToDelete.Parent;
                if(NodeToDelete.Parent.Children == null) NodeToDelete.Parent.Children = new List<SimpleTreeNode<T>>();
                NodeToDelete.Parent.Children.AddRange(NodeToDelete.Children);
            }
            NodeToDelete.Parent = null;   
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            // ваш код выдачи всех узлов дерева в определённом порядке
            var result = new List<SimpleTreeNode<T>>();
            FillResult(Root, result);
            return result;
        }

        private static void FillResult(SimpleTreeNode<T> node, List<SimpleTreeNode<T>> result)
        {
            result.Add(node);
            if (node.Children == null) return;
            foreach (var nodeChild in node.Children)
            {
                FillResult(nodeChild, result);
            }
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            // ваш код поиска узлов по значению
            var result = new List<SimpleTreeNode<T>>();
            FindResult(Root, result, val);
            return result;
        }

        private void FindResult(SimpleTreeNode<T> node, List<SimpleTreeNode<T>> result, T val)
        {
            if (val.Equals(node.NodeValue)) result.Add(node);
            if (node.Children == null) return;
            foreach (var nodeChild in node.Children)
            {
                FindResult(nodeChild, result, val);
            }
        }

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            // ваш код перемещения узла вместе с его поддеревом -- 
            // в качестве дочернего для узла NewParent
            if (NewParent.Children == null)
                NewParent.Children = new List<SimpleTreeNode<T>>();
            NewParent.Children.Add(OriginalNode);
            if (OriginalNode.Parent != null)
            {
                OriginalNode.Parent.Children.Remove(OriginalNode);
            }

            OriginalNode.Parent = NewParent;
        }

        public int Count()
        {
            // количество всех узлов в дереве
            int counter = 0;
            CountResult(Root, ref counter);
            return counter;
        }

        private static void CountResult(SimpleTreeNode<T> node, ref int counter)
        {
            counter += 1;
            if (node.Children == null) return;
            foreach (var nodeChild in node.Children)
            {
                CountResult(nodeChild, ref counter);
            }
        }

        public int LeafCount()
        {
            // количество листьев в дереве
            int counter = 0;
            LeafResult(Root, ref counter);
            return counter;
        }

        private static void LeafResult(SimpleTreeNode<T> node, ref int counter)
        {
            if (node.Children == null)
            {
                counter += 1;
                return;
            }
            foreach (var nodeChild in node.Children)
            {
                LeafResult(nodeChild, ref counter);
            }
        }

        public void CalcLevelAllNodes()
        {
            EnumerateAndCalcTree(Root);
        }

        private static void EnumerateAndCalcTree(SimpleTreeNode<T> node)
        {
            CalcLevel(node);
            if (node.Children == null) return;
            foreach (var nodeChild in node.Children)
            {
                EnumerateAndCalcTree(nodeChild);
            }
        }

        private static void CalcLevel(SimpleTreeNode<T> node)
        {
            var count = 0;
            CalcLevel(node, ref count);
            node.Level = count;
        }

        private static void CalcLevel(SimpleTreeNode<T> node, ref int count)
        {
            count += 1;
            if (node.Parent == null) return;
            CalcLevel(node.Parent, ref count);
        }

        public List<T> EvenTrees()
        {
            var result = new List<T>();
            MakeEvenTrees(Root, result);
            return result;
        }

        private void MakeEvenTrees(SimpleTreeNode<T> node, List<T> result)
        {
            var lengthList = new List<int>();
            if(node.Children == null) return;
            foreach (var child in node.Children) 
            {
                var counter = 0;
                CountResult(child, ref counter);
                lengthList.Add(counter);
            }

            //if(lengthList.Count == 1 && lengthList[0] % 2 == 1) return; // Criterion for old variant - minimal forrest. Rest one branch and odd
            //Old variant - Minimal forrest. Ищем максимальную нечетную длину. Она останется с этой вершиной
            //var index = GetMaxOddLengthIndex(lengthList); //Old variant - Minimal forrest

            //Ищем максимальную нечетную длину. Она останется с этой вершиной
            //Также вершины с одним элементом добавляем в список для игнорирования
            var ignoredIndexList = GetMaxOddLengthIndexAndOnesIndexes(lengthList); 
            //Из оставшихся будем делать чётные деревья. Разрываем их связь с родительской
            for (int i = 0; i < node.Children.Count; i++)
            {
                if(ignoredIndexList.Contains(i)) continue;
                result.Add(node.NodeValue);
                result.Add(node.Children[i].NodeValue);
            }
            //для всех дочерних узлов рекурсивно MakeEvenTrees
            foreach (var child in node.Children)
                MakeEvenTrees(child, result);
        }

        private List<int> GetMaxOddLengthIndexAndOnesIndexes(List<int> lengthList)
        {
            var result = new List<int>();
            var maxOdd = -1;
            for (int i = 0; i < lengthList.Count; i++)
            {
                if(lengthList[i] == 1)
                    result.Add(i);
                else if(lengthList[i] % 2 == 1 && lengthList[i] > maxOdd)
                {
                    result.Add(i);
                    maxOdd = lengthList[i];
                }
            }
            return result;
        }
    }

}