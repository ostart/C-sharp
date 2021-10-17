using System;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
      {
        internal int NodeKey;
        internal BSTNode Parent; // null для корня
        internal BSTNode LeftChild;
        internal BSTNode RightChild;
        internal int NodeLevel;
	
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
		
		public int [] BSTKeysArray;
		
		public BalancedBST() 
		{ 
			Root = null;
		}
		
		public void CreateFromArray(int[] a) 
		{
			Array.Sort(a);
            var result = new int[a.Length];
            ParseArray(a, result, -1, true);
            BSTKeysArray = result;
		}			
			
		public void GenerateTree() 
		{
			Root = GenerateNode(null, null, false, 1);
		}

        private BSTNode GenerateNode(int? parentIndex, BSTNode parentNode, bool isRight, int level)
        {
            if(parentIndex == null)
            {
                var root = new BSTNode(BSTKeysArray[0], null);
                root.NodeLevel = level;
                root.LeftChild = GenerateNode(0, root, false, level+1);
                root.RightChild = GenerateNode(0, root, true, level+1);
                return root;
            }
            var currentIndex = isRight ? 2*(int)parentIndex + 2 : 2*(int)parentIndex + 1;
            if(currentIndex >= BSTKeysArray.Length) return null;
            var node = new BSTNode(BSTKeysArray[currentIndex], parentNode);
            node.NodeLevel = level;
            node.LeftChild = GenerateNode(currentIndex, node, false, level+1);
            node.RightChild = GenerateNode(currentIndex, node, true, level+1);
            return node;
        }

        public bool IsBalanced(BSTNode root_node) 
		{  
			if(root_node == null) return true;
			if(root_node.LeftChild == null && root_node.RightChild == null) return true;
            var isLeftBalanced = IsBalanced(root_node.LeftChild);
            var isRightBalanced = IsBalanced(root_node.RightChild);
            var leftDepth = GetMaxDepth(root_node, false);
            var rightDepth = GetMaxDepth(root_node, true);
            var isCorrectLeftRigthDepth = Math.Abs(leftDepth - rightDepth) <= 1;
            return isLeftBalanced && isRightBalanced && isCorrectLeftRigthDepth;
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