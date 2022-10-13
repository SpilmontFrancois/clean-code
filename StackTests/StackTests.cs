using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackTests
{
    [TestClass]
    public class StackTests
    {
        private Stack _stack = new Stack();

        public StackTests()
        {
            _stack = new Stack();
        }

        [TestMethod]
        public void NewStackIsEmpty()
        {
            Assert.IsTrue(_stack.IsEmpty());
        }

        [TestMethod]
        [DataRow(1)]
        public void AfterPushStackIsNotEmpty(int number1)
        {
            _stack.Push(number1);
            Assert.IsFalse(_stack.IsEmpty());
        }

        [TestMethod]
        public void AfterPopThrowsEmptyException()
        {
            Assert.ThrowsException<Stack.UnderflowException>(() => _stack.Pop());
        }

        [TestMethod]
        [DataRow(1)]
        public void AfterPushAndPopStackIsEmpty(int number1)
        {
            _stack.Push(number1);
            _stack.Pop();
            Assert.IsTrue(_stack.IsEmpty());
        }

        [TestMethod]
        [DataRow(1, 2)]
        public void AfterTwoPushAndOnePopStackIsEmpty(int number1, int number2)
        {
            _stack.Push(number1);
            _stack.Push(number2);
            _stack.Pop();
            Assert.IsFalse(_stack.IsEmpty());
        }

        [TestMethod]
        [DataRow(1)]
        public void AfterPushXFirstElementIsX(int number1)
        {
            _stack.Push(number1);
            Assert.AreEqual(number1, _stack.Items[0]);
        }

        [TestMethod]
        [DataRow(1)]
        public void AfterPushXPopDeletesX(int number1)
        {
            _stack.Push(number1);
            _stack.Pop();
            Assert.AreEqual(0, _stack.Items.Count);
        }
    }
}
