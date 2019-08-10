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
            var node = new SimpleTreeNode<int>(2, root);
            root.Children = new List<SimpleTreeNode<int>> { node };
            var tree = new SimpleTree<int>(root);
            tree.DeleteNode(node);
            Assert.AreEqual(false, root.Children.Contains(node));
        }
        [Test]
        public static void TestGetAllNodes()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var node = new SimpleTreeNode<int>(2, root);
            root.Children = new List<SimpleTreeNode<int>> { node };
            var node3 = new SimpleTreeNode<int>(3, root);
            root.Children.Add(node3);
            var node4 = new SimpleTreeNode<int>(4, node3);
            node3.Children = new List<SimpleTreeNode<int>> {node4};
            var tree = new SimpleTree<int>(root);
            var result = tree.GetAllNodes();
            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public static void TestFindNodesByValue()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var node = new SimpleTreeNode<int>(2, root);
            root.Children = new List<SimpleTreeNode<int>> { node };
            var node3 = new SimpleTreeNode<int>(3, root);
            root.Children.Add(node3);
            var node4 = new SimpleTreeNode<int>(2, node3);
            node3.Children = new List<SimpleTreeNode<int>> { node4 };
            var tree = new SimpleTree<int>(root);

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
            var node = new SimpleTreeNode<int>(2, root);
            root.Children = new List<SimpleTreeNode<int>> { node };
            var node3 = new SimpleTreeNode<int>(3, root);
            root.Children.Add(node3);
            var node4 = new SimpleTreeNode<int>(4, node3);
            node3.Children = new List<SimpleTreeNode<int>> { node4 };
            var tree = new SimpleTree<int>(root);

            Assert.AreEqual(true, root.Children.Contains(node3));

            tree.MoveNode(node3, node);

            Assert.AreEqual(false, root.Children.Contains(node3));
            Assert.AreEqual(true, node.Children.Contains(node3));
        }

        [Test]
        public static void TestCount()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var node = new SimpleTreeNode<int>(2, root);
            root.Children = new List<SimpleTreeNode<int>> { node };
            var node3 = new SimpleTreeNode<int>(3, root);
            root.Children.Add(node3);
            var node4 = new SimpleTreeNode<int>(4, node3);
            node3.Children = new List<SimpleTreeNode<int>> { node4 };
            var tree = new SimpleTree<int>(root);

            var count = tree.Count();
            Assert.AreEqual(4, count);
        }

        [Test]
        public static void TestLeafCount()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var node = new SimpleTreeNode<int>(2, root);
            root.Children = new List<SimpleTreeNode<int>> { node };
            var node3 = new SimpleTreeNode<int>(3, root);
            root.Children.Add(node3);
            var node4 = new SimpleTreeNode<int>(4, node3);
            node3.Children = new List<SimpleTreeNode<int>> { node4 };
            var tree = new SimpleTree<int>(root);

            var count = tree.LeafCount();
            Assert.AreEqual(2, count);
        }

        [Test]
        public static void TestCalcLevelAllNodes()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var node = new SimpleTreeNode<int>(2, root);
            root.Children = new List<SimpleTreeNode<int>> { node };
            var node3 = new SimpleTreeNode<int>(3, root);
            root.Children.Add(node3);
            var node4 = new SimpleTreeNode<int>(4, node3);
            node3.Children = new List<SimpleTreeNode<int>> { node4 };
            var tree = new SimpleTree<int>(root);

            tree.CalcLevelAllNodes();
            Assert.AreEqual(1, root.Level);
            Assert.AreEqual(2, node.Level);
            Assert.AreEqual(2, node3.Level);
            Assert.AreEqual(3, node4.Level);
        }
    }
}
