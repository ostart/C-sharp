using System.Collections.Generic;
using NUnit.Framework;
using AlgorithmsDataStructures2;

namespace Tests
{
    class TestsSimpleTree
    {
        [Test]
        public static void TestAddNodeToTree()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var newNode = new SimpleTreeNode<int>(2, null);
            var tree = new SimpleTree<int>(root);
            tree.AddChild(root, newNode);
            Assert.AreEqual(root, newNode.Parent);
            Assert.AreEqual( true, root.Children.Contains(newNode));
        }

        [Test]
        public static void TestDeleteNodeFromTree()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);
            var node = new SimpleTreeNode<int>(2, root);
            tree.AddChild(root, node);
            var node3 = new SimpleTreeNode<int>(3, null);
            var node4 = new SimpleTreeNode<int>(4, null);
            tree.AddChild(node, node3);
            tree.AddChild(node, node4);

            tree.DeleteNode(node);

            Assert.AreEqual(false, root.Children.Contains(node));
            Assert.AreEqual(true, root.Children.Contains(node3));
            Assert.AreEqual(true, root.Children.Contains(node4));
        }
        
        [Test]
        public static void TestDeleteLeafFromTree()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);
            var node2 = new SimpleTreeNode<int>(2, root);
            tree.AddChild(root, node2);
            var node3 = new SimpleTreeNode<int>(3, root);
            tree.AddChild(root, node3);
            var node4 = new SimpleTreeNode<int>(4, node3); 
            tree.AddChild(node3, node4);
            var count = tree.Count();
            var leafCount = tree.LeafCount();
            Assert.AreEqual(4, count);
            Assert.AreEqual(2, leafCount);

            tree.DeleteNode(node4);

            count = tree.Count();
            leafCount = tree.LeafCount();
            Assert.AreEqual(3, count);
            Assert.AreEqual(2, leafCount);

            Assert.AreEqual(true, root.Children.Contains(node2));
            Assert.AreEqual(true, root.Children.Contains(node3));
            Assert.IsNull(node3.Children);
        }

        [Test]
        public static void TestGetAllNodes()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);
            var node = new SimpleTreeNode<int>(2, root);
            tree.AddChild(root, node);
            var node3 = new SimpleTreeNode<int>(3, root);
            tree.AddChild(root, node3);
            var node4 = new SimpleTreeNode<int>(4, node3);
            tree.AddChild(node3, node4); 
            var result = tree.GetAllNodes();
            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public static void TestFindNodesByValue()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);
            var node = new SimpleTreeNode<int>(2, root);
            tree.AddChild(root, node);
            var node3 = new SimpleTreeNode<int>(3, root);
            tree.AddChild(root, node3);
            var node4 = new SimpleTreeNode<int>(2, node3);
            tree.AddChild(node3, node4);
            
            var testList = new List<SimpleTreeNode<int>>();
            testList.Add(node);
            testList.Add(node4);

            var result = tree.FindNodesByValue(2);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(testList, result);
        }

        [Test]
        public static void TestMoveNode()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);

            var node = new SimpleTreeNode<int>(2, null);
            tree.AddChild(root, node);
            var node3 = new SimpleTreeNode<int>(3, null);
            tree.AddChild(root, node3);
            var node4 = new SimpleTreeNode<int>(4, null);
            tree.AddChild(node3, node4);
            Assert.AreEqual(true, root.Children.Contains(node3));

            tree.MoveNode(node3, node);

            Assert.AreEqual(false, root.Children.Contains(node3));
            Assert.AreEqual(true, node.Children.Contains(node3));
        }

        [Test]
        public static void TestCount()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);
            var node = new SimpleTreeNode<int>(2, root);
            tree.AddChild(root, node);
            var node3 = new SimpleTreeNode<int>(3, root);
            tree.AddChild(root, node3);
            var node4 = new SimpleTreeNode<int>(4, node3);
            tree.AddChild(node3, node4);
            
            var count = tree.Count();
            Assert.AreEqual(4, count);
        }

        [Test]
        public static void TestLeafCount()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);
            var node = new SimpleTreeNode<int>(2, root);
            tree.AddChild(root, node);
            var node3 = new SimpleTreeNode<int>(3, root);
            tree.AddChild(root, node3);
            var node4 = new SimpleTreeNode<int>(4, node3);
            tree.AddChild(node3, node4);
            
            var count = tree.LeafCount();
            Assert.AreEqual(2, count);
        }

        [Test]
        public static void TestCountAndLeafCount()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);

            var node = new SimpleTreeNode<int>(2, root);
            tree.AddChild(root, node);
            var node3 = new SimpleTreeNode<int>(3, root);
            tree.AddChild(root, node3);
            var node4 = new SimpleTreeNode<int>(4, null);
            tree.AddChild(root, node4);
            
            var count = tree.Count();
            Assert.AreEqual(4, count);

            var leafCount = tree.LeafCount();
            Assert.AreEqual(3, leafCount);
        }

        [Test]
        public static void TestCalcLevelAllNodes()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);
            var node = new SimpleTreeNode<int>(2, root);
            tree.AddChild(root, node);
            var node3 = new SimpleTreeNode<int>(3, root);
            tree.AddChild(root, node3);
            var node4 = new SimpleTreeNode<int>(4, node3);
            tree.AddChild(node3, node4);
            
            tree.CalcLevelAllNodes();
            Assert.AreEqual(1, root.Level);
            Assert.AreEqual(2, node.Level);
            Assert.AreEqual(2, node3.Level);
            Assert.AreEqual(3, node4.Level);
        }

        [Test]
        public static void TestEvenTrees()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);
            var node2 = new SimpleTreeNode<int>(2, root);
            tree.AddChild(root, node2);
            var node3 = new SimpleTreeNode<int>(3, root);
            tree.AddChild(root, node3);
            var node6 = new SimpleTreeNode<int>(6, root);
            tree.AddChild(root, node6);
            var node5 = new SimpleTreeNode<int>(5, node2);
            tree.AddChild(node2, node5);
            var node7 = new SimpleTreeNode<int>(7, node2);
            tree.AddChild(node2, node7);
            var node4 = new SimpleTreeNode<int>(4, node3);
            tree.AddChild(node3, node4);
            var node8 = new SimpleTreeNode<int>(8, node6);
            tree.AddChild(node6, node8);
            var node9 = new SimpleTreeNode<int>(9, node8);
            tree.AddChild(node8, node9);
            var node10 = new SimpleTreeNode<int>(10, node8);
            tree.AddChild(node8, node10);
            var list = tree.EvenTrees();
            var ethalon = new List<int> {1,3,1,6};
            Assert.AreEqual(ethalon.Count, list.Count);
            for (int i = 0; i < ethalon.Count; i++)
                Assert.AreEqual(ethalon[i], list[i]);
        }

        [Test]
        public static void TestEvenTreesOldTree()
        {
            var root = new SimpleTreeNode<int>(9, null);
            var tree = new SimpleTree<int>(root);
            var node4 = new SimpleTreeNode<int>(4, root);
            tree.AddChild(root, node4);
            var node17 = new SimpleTreeNode<int>(17, root);
            tree.AddChild(root, node17);
            var node3 = new SimpleTreeNode<int>(3, node4);
            tree.AddChild(node4, node3);
            var node6 = new SimpleTreeNode<int>(6, node4);
            tree.AddChild(node4, node6);
            var node5 = new SimpleTreeNode<int>(5, node6);
            tree.AddChild(node6, node5);
            var node7 = new SimpleTreeNode<int>(7, node6);
            tree.AddChild(node6, node7);
            var node22 = new SimpleTreeNode<int>(22, node17);
            tree.AddChild(node17, node22);
            var node20 = new SimpleTreeNode<int>(20, node22);
            tree.AddChild(node22, node20);
            var list = tree.EvenTrees();
            var ethalon = new List<int> {9,17,17,22};
            Assert.AreEqual(ethalon.Count, list.Count);
            for (int i = 0; i < ethalon.Count; i++)
                Assert.AreEqual(ethalon[i], list[i]);
        }

        [Test]
        public static void TestEvenTreesComplexTree()
        {
            var root = new SimpleTreeNode<int>(9, null);
            var tree = new SimpleTree<int>(root);
            var node4 = new SimpleTreeNode<int>(4, root);
            tree.AddChild(root, node4);
            var node17 = new SimpleTreeNode<int>(17, root);
            tree.AddChild(root, node17);
            var node3 = new SimpleTreeNode<int>(3, node4);
            tree.AddChild(node4, node3);
            var node6 = new SimpleTreeNode<int>(6, node4);
            tree.AddChild(node4, node6);
            var node5 = new SimpleTreeNode<int>(5, node6);
            tree.AddChild(node6, node5);
            var node7 = new SimpleTreeNode<int>(7, node6);
            tree.AddChild(node6, node7);
            var node8 = new SimpleTreeNode<int>(8, node7);
            tree.AddChild(node7, node8);
            var node22 = new SimpleTreeNode<int>(22, node17);
            tree.AddChild(node17, node22);
            var node20 = new SimpleTreeNode<int>(20, node22);
            tree.AddChild(node22, node20);
            var list = tree.EvenTrees();
            var ethalon = new List<int> {9,4,4,6,6,7,17,22};
            Assert.AreEqual(ethalon.Count, list.Count);
            for (int i = 0; i < ethalon.Count; i++)
                Assert.AreEqual(ethalon[i], list[i]);
        }

        [Test]
        public static void TestEvenTreesMoreComplexTree()
        {
            var root = new SimpleTreeNode<int>(9, null);
            var tree = new SimpleTree<int>(root);
            var node4 = new SimpleTreeNode<int>(4, root);
            tree.AddChild(root, node4);
            var node17 = new SimpleTreeNode<int>(17, root);
            tree.AddChild(root, node17);
            var node3 = new SimpleTreeNode<int>(3, node4);
            tree.AddChild(node4, node3);
            var node6 = new SimpleTreeNode<int>(6, node4);
            tree.AddChild(node4, node6);
            var node5 = new SimpleTreeNode<int>(5, node6);
            tree.AddChild(node6, node5);
            var node7 = new SimpleTreeNode<int>(7, node6);
            tree.AddChild(node6, node7);
            var node8 = new SimpleTreeNode<int>(8, node7);
            tree.AddChild(node7, node8);
            var node22 = new SimpleTreeNode<int>(22, node17);
            tree.AddChild(node17, node22);
            var node20 = new SimpleTreeNode<int>(20, node22);
            tree.AddChild(node22, node20);
            var node23 = new SimpleTreeNode<int>(23, node22);
            tree.AddChild(node22, node23);
            var list = tree.EvenTrees();
            var ethalon = new List<int> {9,4,9,17,4,6,6,7};
            Assert.AreEqual(ethalon.Count, list.Count);
            for (int i = 0; i < ethalon.Count; i++)
                Assert.AreEqual(ethalon[i], list[i]);
        }
    }
}
