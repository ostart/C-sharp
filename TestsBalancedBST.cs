using NUnit.Framework;
using AlgorithmsDataStructures2;

namespace Tests
{
    class TestsBalancedBST
    {
        [Test]
        public void TestCreateFromArray()
        {
            var arr = new int[] {10, 12, 8, 14, 7, 6, 15, 13, 11, 1, 9, 2, 3, 4, 5};
            var bst = new BalancedBST();
            bst.CreateFromArray(arr);
            var ethalon = new int[] {8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15};
            Assert.AreEqual(ethalon.Length, bst.BSTKeysArray.Length);
            for(var i = 0; i < bst.BSTKeysArray.Length; i++)
            {
                Assert.AreEqual(ethalon[i], bst.BSTKeysArray[i]);
            }
        }

        [Test]
        public void TestGenerateTree()
        {
            var arr = new int[] {10, 12, 8, 14, 7, 6, 15, 13, 11, 1, 9, 2, 3, 4, 5};
            var bst = new BalancedBST();
            bst.CreateFromArray(arr);
            var ethalon = new int[] {8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15};
            Assert.AreEqual(ethalon.Length, bst.BSTKeysArray.Length);
            for(var i = 0; i < bst.BSTKeysArray.Length; i++)
            {
                Assert.AreEqual(ethalon[i], bst.BSTKeysArray[i]);
            }
            bst.GenerateTree();
            CheckNodes(bst.Root);
        }

        private void CheckNodes(BSTNode node)
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
            var bst = new BalancedBST();
            bst.CreateFromArray(arr);
            var ethalon = new int[] {8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15};
            Assert.AreEqual(ethalon.Length, bst.BSTKeysArray.Length);
            for(var i = 0; i < bst.BSTKeysArray.Length; i++)
            {
                Assert.AreEqual(ethalon[i], bst.BSTKeysArray[i]);
            }
            bst.GenerateTree();
            CheckNodes(bst.Root);
            Assert.IsTrue(bst.IsBalanced(bst.Root));
        }

        [Test]
        public void TestIsBalancedFalse()
        {
            var bst = new BalancedBST();
            var root = new BSTNode(9, null);
            var four = new BSTNode(4, root);
            root.LeftChild = four;
            var seventeen = new BSTNode(17, root);
            root.RightChild = seventeen;
            var three = new BSTNode(3, four);
            four.LeftChild = three;
            var six = new BSTNode(6, four);
            four.RightChild = six;
            var five = new BSTNode(5, six);
            six.LeftChild = five;
            var seven = new BSTNode(7, six);
            six.RightChild = seven;
            var twentytwo = new BSTNode(22, seventeen);
            seventeen.RightChild = twentytwo;
            var twenty = new BSTNode(20, twentytwo);
            twentytwo.LeftChild = twenty;
            Assert.IsFalse(bst.IsBalanced(root));
        }
    }
}