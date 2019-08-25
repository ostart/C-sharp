using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
      public class BSTNode
      {
        public int NodeKey; // ключ узла
        public BSTNode Parent; // родитель или null для корня
        public BSTNode LeftChild; // левый потомок
        public BSTNode RightChild; // правый потомок	
        public int     Level; // глубина узла
	
        public BSTNode(int key, BSTNode parent)
         {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
          }
        }	


	public class BalancedBST
	{
		public BSTNode Root;
		
		public int [] BSTArray; // временный массив для ключей дерева
		
		public BalancedBST() 
		{ 
			Root = null;
		}
		
		public void CreateFromArray(int[] a) 
		{  
			// создаём массив дерева BSTArray из заданного
            BSTArray = a;
			Array.Sort(BSTArray);
		}		
			
		public void GenerateTree() 
		{  
			// создаём дерево с нуля из массива BSTArray
			Root = CreateNode(BSTArray, 1, null);
		}

        private BSTNode CreateNode(int[] array, int level, BSTNode parent)
        {
            var center = array.Length / 2;
            var node = new BSTNode(array[center], parent);
            node.Level = level;
            if (center == 0) return node;
            var left = new int[center];
            var right = new int[center];
            Array.Copy(array, left, center);
            Array.Copy(array, center + 1, right, 0, center);
            node.LeftChild = CreateNode(left, level + 1, node);
            node.RightChild = CreateNode(right, level + 1, node);
            return node;
        }

        public bool IsBalanced(BSTNode root_node) 
		{  
            if(root_node == null) return true;
			if(root_node.LeftChild == null && root_node.RightChild == null) return true;
            var leftBalanced = IsBalanced(root_node.LeftChild);
            var rightBalanced = IsBalanced(root_node.RightChild);
            var leftDepth = GetMaxDepth(root_node, false);
            var rightDepth = GetMaxDepth(root_node, true);
            var correctLeftRigthDepth = Math.Abs(leftDepth - rightDepth) <= 1;
            return leftBalanced && rightBalanced && correctLeftRigthDepth;
		}

        private int GetMaxDepth(BSTNode node, bool isRight)
        {
            if(isRight)
            {
                if(node.RightChild == null) return 0;
                int maxDepth = 0;
                RecursiveMaxDepthCheck(node.RightChild, 1, ref maxDepth);
                return maxDepth;
            }
            else
            {
                if(node.LeftChild == null) return 0;
                int maxDepth = 0;
                RecursiveMaxDepthCheck(node.LeftChild, 1, ref maxDepth);
                return maxDepth;
            }
        }

        private void RecursiveMaxDepthCheck(BSTNode node, int currentDepth, ref int maxDepth)
        {
            if(node.LeftChild == null && node.RightChild == null)
            {
                if(maxDepth < currentDepth)
                    maxDepth = currentDepth;
            }
            if(node.LeftChild != null)
                RecursiveMaxDepthCheck(node.LeftChild, currentDepth + 1, ref maxDepth);
            if(node.RightChild != null)
                RecursiveMaxDepthCheck(node.RightChild, currentDepth + 1, ref maxDepth);
        }
    }
}  