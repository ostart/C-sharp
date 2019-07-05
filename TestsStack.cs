using NUnit.Framework;
using AlgorithmsDataStructures;

namespace Tests
{
    public class TestsStack
    {
        [Test]
        public static void TestStackMethods()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(0, stack.Size(), "TestSize must be 0, but not");
            stack.Push(1);
            Assert.AreEqual(1, stack.Size(), "TestSize must be 1, but not");
            stack.Push(2);
            Assert.AreEqual(2, stack.Size(), "TestSize must be 2, but not");
            stack.Push(3);
            Assert.AreEqual(3, stack.Size(), "TestSize must be 3, but not");
            var top = stack.Peek();
            Assert.AreEqual(3, top, "TestStackMethods Peek value must be 3");
            var value = stack.Pop();
            Assert.AreEqual(3, value, "TestStackMethods Pop value must be 3");
            Assert.AreEqual(2, stack.Size(), "TestSize must be 2, but not");
            value = stack.Pop();
            Assert.AreEqual(2, value, "TestStackMethods Pop value must be 2");
            Assert.AreEqual(1, stack.Size(), "TestSize must be 1, but not");
            value = stack.Pop();
            Assert.AreEqual(1, value, "TestStackMethods Pop value must be 1");
            Assert.AreEqual(0, stack.Size(), "TestSize must be 0, but not");
            value = stack.Pop();
            Assert.AreEqual(0, stack.Peek(), "TestStackMethods stack is not empty");
            Assert.AreEqual(0, value, "TestStackMethods stack is not empty");
            Assert.AreEqual(0, stack.Peek(), "TestStackMethods stack is not empty");
        }

        [Test]
        public static void TestStack2Methods()
        {
            var stack = new Stack2<int>();
            Assert.AreEqual(0, stack.Size(), "TestSize must be 0, but not");
            stack.Push(1);
            Assert.AreEqual(1, stack.Size(), "TestSize must be 1, but not");
            stack.Push(2);
            Assert.AreEqual(2, stack.Size(), "TestSize must be 2, but not");
            stack.Push(3);
            Assert.AreEqual(3, stack.Size(), "TestSize must be 3, but not");
            var top = stack.Peek();
            Assert.AreEqual(3, top, "TestStackMethods Peek value must be 3");
            var value = stack.Pop();
            Assert.AreEqual(3, value, "TestStackMethods Pop value must be 3");
            Assert.AreEqual(2, stack.Size(), "TestSize must be 2, but not");
            value = stack.Pop();
            Assert.AreEqual(2, value, "TestStackMethods Pop value must be 2");
            Assert.AreEqual(1, stack.Size(), "TestSize must be 1, but not");
            value = stack.Pop();
            Assert.AreEqual(1, value, "TestStackMethods Pop value must be 1");
            Assert.AreEqual(0, stack.Size(), "TestSize must be 0, but not");
            value = stack.Pop();
            Assert.AreEqual(0, stack.Peek(), "TestStackMethods stack is not empty");
            Assert.AreEqual(0, value, "TestStackMethods stack is not empty");
            Assert.AreEqual(0, stack.Peek(), "TestStackMethods stack is not empty");
        }

        [Test]
        public static void TestIsBalanced()
        {
            Assert.IsTrue(StackExtra.IsBalances("(()((())()))"));
            Assert.IsFalse(StackExtra.IsBalances("(()()(()"));
            Assert.IsFalse(StackExtra.IsBalances("())("));
            Assert.IsFalse(StackExtra.IsBalances("))(("));
            Assert.IsFalse(StackExtra.IsBalances("((())"));
        }

        [Test]
        public static void TestBonusPolishNotation()
        {
            Assert.AreEqual(59, StackExtra.CalculatePolishNotation("8 2 + 5 * 9 + ="));

            Assert.AreEqual(9, StackExtra.CalculatePolishNotation("1 2 + 3 * ="));
        }
    }
}
