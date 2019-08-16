using System;
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

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            // ищем максимальное/минимальное в поддереве
            if (FindMax)
            {
                if (FromNode.RightChild != null)
                    return FinMinMax(FromNode.RightChild, FindMax);
                return FromNode;
            }
            else
            {
                if (FromNode.LeftChild != null)
                    return FinMinMax(FromNode.LeftChild, FindMax);
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

            var min = FinMinMax(node.Node.RightChild, false);
            if (min.RightChild != null) // если есть у min ветка (RightChild) с большим значением
            {
                min.Parent.LeftChild = min.RightChild;
                min.RightChild.Parent = min.Parent;
            }
            else
            {   // отвязываем min узел от родителя
                if (min.NodeKey < min.Parent.NodeKey)
                    min.Parent.LeftChild = null;     
            }          
            if (node.Node.Parent.NodeKey < node.Node.NodeKey)
                node.Node.Parent.RightChild = min;
            else
                node.Node.Parent.LeftChild = min;
            min.Parent = node.Node.Parent;
            if (min == node.Node.RightChild)
                min.RightChild = null;
            else
            {
                min.RightChild =  node.Node.RightChild;
                if (node.Node.RightChild != null)
                    node.Node.RightChild.Parent = min;
            }
            if (min == node.Node.LeftChild)
                min.LeftChild = null;
            else
            {
                min.LeftChild = node.Node.LeftChild;
                if (node.Node.LeftChild != null)
                    node.Node.LeftChild.Parent = min;
            }
            return true;
        }

        public int Count()
        {
            var counter = 0;
            CalcCount(Root, ref counter);
            return counter; // количество узлов в дереве
        }

        private static void CalcCount(BSTNode<T> node, ref int counter)
        {
            counter += 1;
            if (node.LeftChild != null)
                CalcCount(node.LeftChild, ref counter);
            if (node.RightChild != null)
                CalcCount(node.RightChild, ref counter);
        }
    }
}
