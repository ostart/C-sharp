using NUnit.Framework;
using AlgorithmsDataStructures6;
using System;

namespace Tests
{
    [TestFixture]
    public class TestsBWT
    {
        [Test]
        public void TestBWT_NegativeCase_InvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new BWT(3, 3, false));
        }

        [Test]
        public void TestBWT_PositiveCase_CorrectTreeStructure()
        {
            var bwt = new BWT(3, 4, true);
            foreach (var node in bwt.DescendingTree)
            {
                Assert.IsTrue(node.ParentColor != node.LeftChildColor && node.ParentColor != node.RightChildColor && node.LeftChildColor != node.RightChildColor);
            }
            foreach (var node in bwt.AscendingTree)
            {
                Assert.IsTrue(node.ParentColor != node.LeftChildColor && node.ParentColor != node.RightChildColor && node.LeftChildColor != node.RightChildColor);
            }
        }

        [Test]
        public void TestBWT_PositiveCase_SymmetricTree()
        {
            var bwt = new BWT(3, 4, true);
            var rootDesc = bwt.RootOfDescendingTree;
            var rootAsc = bwt.RootOfAscendingTree;
            Assert.IsTrue(rootDesc.ParentColor == rootAsc.ParentColor);
            Assert.IsTrue(rootDesc.LeftChildColor == rootAsc.RightChildColor);
            Assert.IsTrue(rootDesc.RightChildColor == rootAsc.LeftChildColor);

            Assert.IsTrue(rootDesc.LeftChild.ParentColor == rootAsc.RightChild.ParentColor);
            Assert.IsTrue(rootDesc.LeftChild.LeftChildColor == rootAsc.RightChild.RightChildColor);
            Assert.IsTrue(rootDesc.LeftChild.RightChildColor == rootAsc.RightChild.LeftChildColor);

            Assert.IsTrue(rootDesc.RightChild.ParentColor == rootAsc.LeftChild.ParentColor);
            Assert.IsTrue(rootDesc.RightChild.LeftChildColor == rootAsc.LeftChild.RightChildColor);
            Assert.IsTrue(rootDesc.RightChild.RightChildColor == rootAsc.LeftChild.LeftChildColor);

            Assert.IsTrue(rootDesc.LeftChild.LeftChild.ParentColor == rootAsc.RightChild.RightChild.ParentColor);
            Assert.IsTrue(rootDesc.LeftChild.LeftChild.LeftChildColor == rootAsc.RightChild.RightChild.RightChildColor);
            Assert.IsTrue(rootDesc.LeftChild.LeftChild.RightChildColor == rootAsc.RightChild.RightChild.LeftChildColor);

            Assert.IsTrue(rootDesc.LeftChild.RightChild.ParentColor == rootAsc.RightChild.LeftChild.ParentColor);
            Assert.IsTrue(rootDesc.LeftChild.RightChild.LeftChildColor == rootAsc.RightChild.LeftChild.RightChildColor);
            Assert.IsTrue(rootDesc.LeftChild.RightChild.RightChildColor == rootAsc.RightChild.LeftChild.LeftChildColor);
        }
    }
}