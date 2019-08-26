using NUnit.Framework;
using AlgorithmsDataStructures2;
using System;

namespace Tests
{
    class myTestsBalancedBST
    {
        [Test]
        public void TestCreateFromArray()
        {
            var arr = new int[] {10, 12, 8, 14, 7, 6, 15, 13, 11, 1, 9, 2, 3, 4, 5};
            var bst = new myBalancedBST();
            bst.CreateFromArray(arr);
            Assert.AreEqual(arr.Length, bst.BSTArray.Length);
            for(var i = 0; i < bst.BSTArray.Length; i++)
            {
                Assert.AreEqual(i + 1, bst.BSTArray[i]);
            }
        }

        [Test]
        public void TestGenerateTree()
        {
            var arr = new int[] {10, 12, 8, 14, 7, 6, 15, 13, 11, 1, 9, 2, 3, 4, 5};
            var bst = new myBalancedBST();
            bst.CreateFromArray(arr);
            Assert.AreEqual(arr.Length, bst.BSTArray.Length);
            for(var i = 0; i < bst.BSTArray.Length; i++)
            {
                Assert.AreEqual(i + 1, bst.BSTArray[i]);
            }
            bst.GenerateTree();
            CheckNodes(bst.Root);
        }

        private void CheckNodes(myBSTNode node)
        {
            if(node.LeftChild == null && node.RightChild == null) return;
            if(node.LeftChild != null)
            {
                Assert.Less(node.LeftChild.NodeKey, node.NodeKey);
                CheckNodes(node.LeftChild);
            }
            if(node.RightChild != null)
            {
                Assert.GreaterOrEqual(node.RightChild.NodeKey, node.NodeKey);
                CheckNodes(node.RightChild);
            }
        }

        [Test]
        public void TestIsBalanced()
        {
            var arr = new int[] {10, 12, 8, 14, 7, 6, 15, 13, 11, 1, 9, 2, 3, 4, 5};
            var bst = new myBalancedBST();
            bst.CreateFromArray(arr);
            Assert.AreEqual(arr.Length, bst.BSTArray.Length);
            for(var i = 0; i < bst.BSTArray.Length; i++)
            {
                Assert.AreEqual(i + 1, bst.BSTArray[i]);
            }
            bst.GenerateTree();
            CheckNodes(bst.Root);
            Assert.IsTrue(bst.IsBalanced(bst.Root));
        }

        [Test]
        public void TestIsBalancedFalse()
        {
            var bst = new myBalancedBST();
            var root = new myBSTNode(9, null);
            var four = new myBSTNode(4, root);
            root.LeftChild = four;
            var seventeen = new myBSTNode(17, root);
            root.RightChild = seventeen;
            var three = new myBSTNode(3, four);
            four.LeftChild = three;
            var six = new myBSTNode(6, four);
            four.RightChild = six;
            var five = new myBSTNode(5, six);
            six.LeftChild = five;
            var seven = new myBSTNode(7, six);
            six.RightChild = seven;
            var twentytwo = new myBSTNode(22, seventeen);
            seventeen.RightChild = twentytwo;
            var twenty = new myBSTNode(20, twentytwo);
            twentytwo.LeftChild = twenty;
            Assert.IsFalse(bst.IsBalanced(root));
        }
    }
}