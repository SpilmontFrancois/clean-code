using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        [DataRow(10, 20, 30)]
        public void addTwoElements_ShouldReturnRightResult(int number1, int number2, int result)
        {
            var calculator = new Calculator();
            Assert.AreEqual(result, calculator.Add(number1, number2));
        }

        [TestMethod]
        [DataRow(20, 10, 10)]
        public void substractTwoElements_ShouldReturnRightResult(int number1, int number2, int result)
        {
            var calculator = new Calculator();
            Assert.AreEqual(result, calculator.Substract(number1, number2));
        }

        [TestMethod]
        [DataRow(10, 20, 200)]
        public void multiplyTwoElements_ShouldReturnRightResult(int number1, int number2, int result)
        {
            var calculator = new Calculator();
            Assert.AreEqual(result, calculator.Multiply(number1, number2));
        }

        [TestMethod]
        [DataRow(20, 10, 2)]
        public void divideTwoElements_ShouldReturnRightResult(int number1, int number2, int result)
        {
            var calculator = new Calculator();
            Assert.AreEqual(result, calculator.Divide(number1, number2));
        }

        [TestMethod]
        [DataRow(-10, 20)]
        [ExpectedException(typeof(NegativeException))]
        public void addTwoElements_ShouldNotBeNegative(int number1, int number2)
        {
            var calculator = new Calculator();
            calculator.Add(number1, number2);
        }

        [TestMethod]
        [DataRow(-10, 20)]
        [ExpectedException(typeof(NegativeException))]
        public void substractTwoElements_ShouldNotBeNegative(int number1, int number2)
        {
            var calculator = new Calculator();
            calculator.Substract(number1, number2);
        }

        [TestMethod]
        [DataRow(-10, 20)]
        [ExpectedException(typeof(NegativeException))]
        public void multiplyTwoElements_ShouldNotBeNegative(int number1, int number2)
        {
            var calculator = new Calculator();
            calculator.Multiply(number1, number2);
        }

        [TestMethod]
        [DataRow(-10, 20)]
        [ExpectedException(typeof(NegativeException))]
        public void divideTwoElements_ShouldNotBeNegative(int number1, int number2)
        {
            var calculator = new Calculator();
            calculator.Divide(number1, number2);
        }

        [TestMethod]
        [DataRow(10, 0)]
        [ExpectedException(typeof(DivideByZeroException))]
        public void divideTwoElements_CannotDivideByZero(int number1, int number2)
        {
            var calculator = new Calculator();
            calculator.Divide(number1, number2);
            // Assert.ThrowsException<DivideByZeroException>(() => calculator.Divide(number1, number2));
        }
    }
}
