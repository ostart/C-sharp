using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; // ключ узла
        public T NodeValue; // значение в узле
        public BSTNode<T> Parent; // родитель или null для корня
        public BSTNode<T> LeftChild; // левый потомок
        public BSTNode<T> RightChild; // правый потомок	

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    // промежуточный результат поиска
    public class BSTFind<T>
    {
        // null если не найден узел, и в дереве только один корень
        public BSTNode<T> Node;

        // true если узел найден
        public bool NodeHasKey;

        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;

        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        BSTNode<T> Root; // корень дерева, или null

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            // ищем в дереве узел и сопутствующую информацию по ключу
            return GetNodeByKey(Root, key);
        }

        private static BSTFind<T> GetNodeByKey(BSTNode<T> node, int key)
        {
            if (node.NodeKey > key)
                return node.LeftChild != null ? GetNodeByKey(node.LeftChild, key) : new BSTFind<T> { Node = node, NodeHasKey = false, ToLeft = true };
            else if (node.NodeKey < key)
                return node.RightChild != null ? GetNodeByKey(node.RightChild, key) : new BSTFind<T> { Node = node, NodeHasKey = false, ToLeft = false };
            else
                return new BSTFind<T> { Node = node, NodeHasKey = true };
        }

        public bool AddKeyValue(int key, T val)
        {
            // добавляем ключ-значение в дерево
            var node = FindNodeByKey(key);
            if (node.NodeHasKey)
                return false; // если ключ уже есть
            if (node.ToLeft)
                node.Node.LeftChild = new BSTNode<T>(key, val, node.Node);
            else
                node.Node.RightChild = new BSTNode<T>(key, val, node.Node);
            return true;
        }

        public BSTNode<T> FindMinOrMaxValueInSubTree(BSTNode<T> FromNode, bool FindMax)
        {
            // ищем максимальное/минимальное в поддереве
            if (FindMax)
            {
                if (FromNode.RightChild != null)
                    return FindMinOrMaxValueInSubTree(FromNode.RightChild, FindMax);
                return FromNode;
            }
            else
            {
                if (FromNode.LeftChild != null)
                    return FindMinOrMaxValueInSubTree(FromNode.LeftChild, FindMax);
                return FromNode;
            }
        }

        public bool DeleteNodeByKey(int key)
        {
            // удаляем узел по ключу
            var node = FindNodeByKey(key);
            if (!node.NodeHasKey)
                return false; // если узел не найден
            if (node.Node.RightChild == null && node.Node.LeftChild == null)
            {
                if (node.Node.Parent.NodeKey < node.Node.NodeKey)
                    node.Node.Parent.RightChild = null;
                else
                    node.Node.Parent.LeftChild = null;
                return true;
            }
            if (node.Node.RightChild == null)
            {
                if (node.Node.Parent.NodeKey < node.Node.NodeKey)
                    node.Node.Parent.RightChild = node.Node.LeftChild;   
                else
                    node.Node.Parent.LeftChild = node.Node.LeftChild;
                node.Node.LeftChild.Parent = node.Node.Parent;
                return true;
            }

            var minLeft = FindMinOrMaxValueInSubTree(node.Node.RightChild, false);
            if (minLeft.RightChild != null) // если есть у min ветка (RightChild) с большим значением
            {
                minLeft.Parent.LeftChild = minLeft.RightChild;
                minLeft.RightChild.Parent = minLeft.Parent;
            }
            else
            {   // отвязываем min узел от родителя
                if (minLeft.NodeKey < minLeft.Parent.NodeKey)
                    minLeft.Parent.LeftChild = null;     
            }          
            if (node.Node.Parent.NodeKey < node.Node.NodeKey)
                node.Node.Parent.RightChild = minLeft;
            else
                node.Node.Parent.LeftChild = minLeft;
            minLeft.Parent = node.Node.Parent;
            if (minLeft == node.Node.RightChild)
                minLeft.RightChild = null;
            else
            {
                minLeft.RightChild =  node.Node.RightChild;
                if (node.Node.RightChild != null)
                    node.Node.RightChild.Parent = minLeft;
            }
            if (minLeft == node.Node.LeftChild)
                minLeft.LeftChild = null;
            else
            {
                minLeft.LeftChild = node.Node.LeftChild;
                if (node.Node.LeftChild != null)
                    node.Node.LeftChild.Parent = minLeft;
            }
            return true;
        }

        public int Count()
        {
            var counter = 0;
            CalculateNodesInTreeToGetCounter(Root, ref counter);
            return counter; // количество узлов в дереве
        }

        private static void CalculateNodesInTreeToGetCounter(BSTNode<T> node, ref int counter)
        {
            counter += 1;
            if (node.LeftChild != null)
                CalculateNodesInTreeToGetCounter(node.LeftChild, ref counter);
            if (node.RightChild != null)
                CalculateNodesInTreeToGetCounter(node.RightChild, ref counter);
        }

        public List<BSTNode<T>> WideAllNodes()
        {
            var result = new List<BSTNode<T>>();
            FillWideAllNodes(new List<BSTNode<T>>{ Root }, result);
            return result;
        }

        private static void FillWideAllNodes(List<BSTNode<T>> nodes, List<BSTNode<T>> result)
        {
            if (nodes.Count == 0) return;
            result.AddRange(nodes);
            var nodesBelow = new List<BSTNode<T>>();
            foreach (BSTNode<T> bstNode in nodes)
            {
                if (bstNode.LeftChild != null) nodesBelow.Add(bstNode.LeftChild);
                if (bstNode.RightChild != null) nodesBelow.Add(bstNode.RightChild);
            }
            if (nodesBelow.Count == 0) return;
            FillWideAllNodes(nodesBelow, result);
        }

        public List<BSTNode<T>> DeepAllNodes(int order) // 0 (in-order), 1 (post-order) и 2 (pre-order)
        {
            var result = new List<BSTNode<T>>();
            switch (order)
            {
                case 0:
                    FillDeepAllNodesInOrder(Root, result);
                    break;
                case 1:
                    FillDeepAllNodesPostOrder(Root, result);
                    break;
                case 2:
                    FillDeepAllNodesPreOrder(Root, result);
                    break;
                default:
                    FillDeepAllNodesInOrder(Root, result);
                    break;
            }            
            return result;
        }

        private static void FillDeepAllNodesPreOrder(BSTNode<T> node, List<BSTNode<T>> result) // current, left-recurse, right-recurse
        {
            result.Add(node);
            if (node.LeftChild != null)
                FillDeepAllNodesPreOrder(node.LeftChild, result);
            if (node.RightChild != null)
                FillDeepAllNodesPreOrder(node.RightChild, result);
        }

        private static void FillDeepAllNodesPostOrder(BSTNode<T> node, List<BSTNode<T>> result) // left-recurse, right-recurse, current
        {
            if (node.LeftChild != null)
                FillDeepAllNodesPostOrder(node.LeftChild, result);
            if (node.RightChild != null)
                FillDeepAllNodesPostOrder(node.RightChild, result);
            result.Add(node);
        }

        private static void FillDeepAllNodesInOrder(BSTNode<T> node, List<BSTNode<T>> result) // left-recurse, current, right-recurse
        {
            if (node.LeftChild != null)
                FillDeepAllNodesInOrder(node.LeftChild, result);
            result.Add(node);
            if (node.RightChild != null)
                FillDeepAllNodesInOrder(node.RightChild, result);
        }
    }
}
