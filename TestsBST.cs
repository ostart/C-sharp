using NUnit.Framework;
using AlgorithmsDataStructures2;

namespace Tests
{
    class TestsBST
    {
        private BST<int> _tree;

        [SetUp]
        public void TestsSetup()
        {
            var root = new BSTNode<int>(9, 9, null);
            var four = new BSTNode<int>(4, 4, root);
            root.LeftChild = four;
            var seventeen = new BSTNode<int>(17, 17, root);
            root.RightChild = seventeen;
            var three = new BSTNode<int>(3, 3, four);
            four.LeftChild = three;
            var six = new BSTNode<int>(6, 6, four);
            four.RightChild = six;
            var five = new BSTNode<int>(5, 5, six);
            six.LeftChild = five;
            var seven = new BSTNode<int>(7, 7, six);
            six.RightChild = seven;
            var twentytwo = new BSTNode<int>(22, 22, seventeen);
            seventeen.RightChild = twentytwo;
            var twenty = new BSTNode<int>(20, 20, twentytwo);
            twentytwo.LeftChild = twenty;
            _tree = new BST<int>(root);
        }

        [TearDown]
        public void TestsTeardown()
        {
            _tree = null;
        }

        [Test]
        public void TestFindNodeByKey()
        {
            var sixteenResult = _tree.FindNodeByKey(16);
            Assert.IsNotNull(sixteenResult.Node);
            Assert.AreEqual(17, sixteenResult.Node.NodeKey);
            Assert.AreEqual(false, sixteenResult.NodeHasKey);
            Assert.AreEqual(true, sixteenResult.ToLeft);

            var twentythreeResult = _tree.FindNodeByKey(23);
            Assert.IsNotNull(twentythreeResult.Node);
            Assert.AreEqual(22, twentythreeResult.Node.NodeKey);
            Assert.AreEqual(false, twentythreeResult.NodeHasKey);
            Assert.AreEqual(false, twentythreeResult.ToLeft);

            var sixResult = _tree.FindNodeByKey(6);
            Assert.IsNotNull(sixResult.Node);
            Assert.AreEqual(6, sixResult.Node.NodeKey);
            Assert.AreEqual(true, sixResult.NodeHasKey);
            Assert.AreEqual(false, sixResult.ToLeft);
        }

        [Test]
        public void TestAddKeyValue()
        {
            var sixteenResult = _tree.FindNodeByKey(16);
            Assert.IsNotNull(sixteenResult.Node);
            Assert.AreEqual(17, sixteenResult.Node.NodeKey);
            Assert.AreEqual(false, sixteenResult.NodeHasKey);
            Assert.AreEqual(true, sixteenResult.ToLeft);

            Assert.AreEqual(true, _tree.AddKeyValue(16, 16));

            sixteenResult = _tree.FindNodeByKey(16);
            Assert.IsNotNull(sixteenResult.Node);
            Assert.AreEqual(16, sixteenResult.Node.NodeKey);
            Assert.AreEqual(true, sixteenResult.NodeHasKey);
            Assert.AreEqual(false, sixteenResult.ToLeft);

            var twentythreeResult = _tree.FindNodeByKey(23);
            Assert.IsNotNull(twentythreeResult.Node);
            Assert.AreEqual(22, twentythreeResult.Node.NodeKey);
            Assert.AreEqual(false, twentythreeResult.NodeHasKey);
            Assert.AreEqual(false, twentythreeResult.ToLeft);

            Assert.AreEqual(true, _tree.AddKeyValue(23, 23));

            twentythreeResult = _tree.FindNodeByKey(23);
            Assert.IsNotNull(twentythreeResult.Node);
            Assert.AreEqual(23, twentythreeResult.Node.NodeKey);
            Assert.AreEqual(true, twentythreeResult.NodeHasKey);
            Assert.AreEqual(false, twentythreeResult.ToLeft);

            var sixResult = _tree.FindNodeByKey(6);
            Assert.IsNotNull(sixResult.Node);
            Assert.AreEqual(6, sixResult.Node.NodeKey);
            Assert.AreEqual(true, sixResult.NodeHasKey);
            Assert.AreEqual(false, sixResult.ToLeft);

            Assert.AreEqual(false, _tree.AddKeyValue(6, 6));

            sixResult = _tree.FindNodeByKey(6);
            Assert.IsNotNull(sixResult.Node);
            Assert.AreEqual(6, sixResult.Node.NodeKey);
            Assert.AreEqual(true, sixResult.NodeHasKey);
            Assert.AreEqual(false, sixResult.ToLeft);
        }

        [Test]
        public void TestFindMinMax()
        {
            var root = new BSTNode<int>(9, 9, null);
            var four = new BSTNode<int>(4, 4, root);
            root.LeftChild = four;
            var seventeen = new BSTNode<int>(17, 17, root);
            root.RightChild = seventeen;
            var three = new BSTNode<int>(3, 3, four);
            four.LeftChild = three;
            var six = new BSTNode<int>(6, 6, four);
            four.RightChild = six;
            var five = new BSTNode<int>(5, 5, six);
            six.LeftChild = five;
            var seven = new BSTNode<int>(7, 7, six);
            six.RightChild = seven;
            var twentytwo = new BSTNode<int>(22, 22, seventeen);
            seventeen.RightChild = twentytwo;
            var twenty = new BSTNode<int>(20, 20, twentytwo);
            twentytwo.LeftChild = twenty;
            var tree = new BST<int>(root);

            var min = tree.FinMinMax(root, false);
            Assert.AreEqual(3, min.NodeKey);

            var max = tree.FinMinMax(root, true);
            Assert.AreEqual(22, max.NodeKey);

            var localMin = tree.FinMinMax(twentytwo, false);
            Assert.AreEqual(20, localMin.NodeKey);

            var localMax = tree.FinMinMax(four, true);
            Assert.AreEqual(7, localMax.NodeKey);
        }

        [Test]
        public void TestCount()
        {
            Assert.AreEqual(9, _tree.Count());
        }

        [Test]
        public void TestDeleteNodeByNotExistingKey55()
        {
            Assert.AreEqual(9, _tree.Count());
            Assert.AreEqual(false, _tree.DeleteNodeByKey(55));
            Assert.AreEqual(9, _tree.Count());
        }

        [Test]
        public void TestDeleteNodeByKey5()
        {
            var fiveResult = _tree.FindNodeByKey(5);
            Assert.IsNotNull(fiveResult.Node);
            Assert.AreEqual(5, fiveResult.Node.NodeKey);
            Assert.AreEqual(true, fiveResult.NodeHasKey);
            Assert.AreEqual(false, fiveResult.ToLeft);

            Assert.AreEqual(true, _tree.DeleteNodeByKey(5));
            Assert.AreEqual(8, _tree.Count());

            fiveResult = _tree.FindNodeByKey(5);
            Assert.IsNotNull(fiveResult.Node);
            Assert.AreEqual(6, fiveResult.Node.NodeKey);
            Assert.AreEqual(false, fiveResult.NodeHasKey);
            Assert.AreEqual(true, fiveResult.ToLeft);
        }

        [Test]
        public void TestDeleteNodeByKey7()
        {
            var sevenResult = _tree.FindNodeByKey(7);
            Assert.IsNotNull(sevenResult.Node);
            Assert.AreEqual(7, sevenResult.Node.NodeKey);
            Assert.AreEqual(true, sevenResult.NodeHasKey);
            Assert.AreEqual(false, sevenResult.ToLeft);

            Assert.AreEqual(true, _tree.DeleteNodeByKey(7));
            Assert.AreEqual(8, _tree.Count());

            sevenResult = _tree.FindNodeByKey(7);
            Assert.IsNotNull(sevenResult.Node);
            Assert.AreEqual(6, sevenResult.Node.NodeKey);
            Assert.AreEqual(false, sevenResult.NodeHasKey);
            Assert.AreEqual(false, sevenResult.ToLeft);
        }

        [Test]
        public void TestDeleteNodeByKey6()
        {
            var sixResult = _tree.FindNodeByKey(6);
            Assert.IsNotNull(sixResult.Node);
            Assert.AreEqual(6, sixResult.Node.NodeKey);
            Assert.AreEqual(true, sixResult.NodeHasKey);
            Assert.AreEqual(false, sixResult.ToLeft);

            Assert.AreEqual(true, _tree.DeleteNodeByKey(6));
            Assert.AreEqual(8, _tree.Count());

            sixResult = _tree.FindNodeByKey(6);
            Assert.IsNotNull(sixResult.Node);
            Assert.AreEqual(5, sixResult.Node.NodeKey);
            Assert.AreEqual(false, sixResult.NodeHasKey);
            Assert.AreEqual(false, sixResult.ToLeft);
        }

        [Test]
        public void TestDeleteNodeByKey4()
        {
            var fourResult = _tree.FindNodeByKey(4);
            Assert.IsNotNull(fourResult.Node);
            Assert.AreEqual(4, fourResult.Node.NodeKey);
            Assert.AreEqual(true, fourResult.NodeHasKey);
            Assert.AreEqual(false, fourResult.ToLeft);

            Assert.AreEqual(true, _tree.DeleteNodeByKey(4));
            Assert.AreEqual(8, _tree.Count());

            fourResult = _tree.FindNodeByKey(4);
            Assert.IsNotNull(fourResult.Node);
            Assert.AreEqual(3, fourResult.Node.NodeKey);
            Assert.AreEqual(false, fourResult.NodeHasKey);
            Assert.AreEqual(false, fourResult.ToLeft);
        }

        [Test]
        public void TestDeleteNodeByKey17()
        {
            var result = _tree.FindNodeByKey(17);
            Assert.IsNotNull(result.Node);
            Assert.AreEqual(17, result.Node.NodeKey);
            Assert.AreEqual(true, result.NodeHasKey);
            Assert.AreEqual(false, result.ToLeft);

            Assert.AreEqual(true, _tree.DeleteNodeByKey(17));
            Assert.AreEqual(8, _tree.Count());

            result = _tree.FindNodeByKey(17);
            Assert.IsNotNull(result.Node);
            Assert.AreEqual(20, result.Node.NodeKey);
            Assert.AreEqual(false, result.NodeHasKey);
            Assert.AreEqual(true, result.ToLeft);
        }

        [Test]
        public void TestDeleteNodeByKey22()
        {
            var result = _tree.FindNodeByKey(22);
            Assert.IsNotNull(result.Node);
            Assert.AreEqual(22, result.Node.NodeKey);
            Assert.AreEqual(true, result.NodeHasKey);
            Assert.AreEqual(false, result.ToLeft);

            Assert.AreEqual(true, _tree.DeleteNodeByKey(22));
            Assert.AreEqual(8, _tree.Count());

            result = _tree.FindNodeByKey(22);
            Assert.IsNotNull(result.Node);
            Assert.AreEqual(20, result.Node.NodeKey);
            Assert.AreEqual(false, result.NodeHasKey);
            Assert.AreEqual(false, result.ToLeft);
        }

        [Test]
        public void TestWideAllNodes()
        {
            var result = _tree.WideAllNodes();
            Assert.AreEqual(9, result.Count);
            int[] mas = {9, 4, 17, 3, 6, 22, 5, 7, 20};
            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(mas[i], result[i].NodeKey);
            }
        }

        [Test]
        public void TestDeepAllNodesInOrder()
        {
            var result = _tree.DeepAllNodes(0);
            Assert.AreEqual(9, result.Count);
            int[] mas = { 3, 4, 5, 6, 7, 9, 17, 20, 22 };
            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(mas[i], result[i].NodeKey);
            }
        }

        [Test]
        public void TestDeepAllNodesPostOrder()
        {
            var result = _tree.DeepAllNodes(1);
            Assert.AreEqual(9, result.Count);
            int[] mas = { 3, 5, 7, 6, 4, 20, 22, 17, 9 };
            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(mas[i], result[i].NodeKey);
            }
        }

        [Test]
        public void TestDeepAllNodesPreOrder()
        {
            var result = _tree.DeepAllNodes(2);
            Assert.AreEqual(9, result.Count);
            int[] mas = { 9, 4, 3, 6, 5, 7, 17, 22, 20 };
            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(mas[i], result[i].NodeKey);
            }
        }
    }
}
