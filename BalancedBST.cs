using System;

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
			Array.Sort(a);
            var result = new int[a.Length];
            ParseArray(a, result, -1, true);
            BSTArray = result;
		}			
			
		public void GenerateTree() 
		{  
			// создаём дерево с нуля из массива BSTArray
			Root = GenerateNode(null, null, false, 1);
		}

        private BSTNode GenerateNode(int? parentIndex, BSTNode parentNode, bool isRight, int level)
        {
            if(parentIndex == null)
            {
                var root = new BSTNode(BSTArray[0], null);
                root.Level = level;
                root.LeftChild = GenerateNode(0, root, false, level+1);
                root.RightChild = GenerateNode(0, root, true, level+1);
                return root;
            }
            var currentIndex = isRight ? 2*(int)parentIndex + 2 : 2*(int)parentIndex + 1;
            if(currentIndex >= BSTArray.Length) return null;
            var node = new BSTNode(BSTArray[currentIndex], parentNode);
            node.Level = level;
            node.LeftChild = GenerateNode(currentIndex, node, false, level+1);
            node.RightChild = GenerateNode(currentIndex, node, true, level+1);
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

        private static void ParseArray(int[] inputArray, int[] result, int parentIndex, bool isRight)
        {
            var center = inputArray.Length / 2;
            var currentIndex = isRight ? (2*parentIndex + 2) : (2*parentIndex + 1);
            result[currentIndex] = inputArray[center];
            if (center == 0) return;
            var left = new int[center];
            var right = new int[center];
            Array.Copy(inputArray, left, center);
            Array.Copy(inputArray, center + 1, right, 0, center);
            ParseArray(left, result, currentIndex, false);
            ParseArray(right, result, currentIndex, true);
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