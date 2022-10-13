using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;

namespace CalculatorUnitTests_MsTests
{
    [TestClass]
    public class CalculatorUnitTests
    {
        //[TestMethod]
        //public void TestStringToArray()
        //{
        //    string numbers = "0,1,2,3,4,555";
        //    var arrayNumbers = numbers.Split(',');

        //    // LinQ
        //    var sum = arrayNumbers.Sum(x => Convert.ToInt32(x));

        //    // Foreach classique
        //    var sommeWithForeach = 0;
        //    foreach (var cell in arrayNumbers)
        //    {
        //        sommeWithForeach += Convert.ToInt32(cell);
        //    }
        //    Assert.AreEqual(sommeWithForeach, 565);
        //    Assert.AreEqual(sum, 565);
        //}

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void AddReturnZeroWhenSuppliedEmptyOrNullString(string numbers)
        {
            var result = Calculator.Add(numbers);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        [DataRow("0", 0)]
        [DataRow("1", 1)]
        [DataRow("2", 2)]
        [DataRow("3", 3)]
        public void AddReturnNumberWhenSuppliedAsSingleNumbers(string number, int expectedResult)
        {
            var result = Calculator.Add(number);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        [DataRow("0", 0)]
        [DataRow("1", 1)]
        [DataRow("2", 2)]
        [DataRow("3", 3)]
        [DataRow("0,1,2,3,4,555", 565)]
        public void AddReturnNumberWhenSuppliedSingleNumberInString(string number, int expectedResult)
        {
            var result = Calculator.Add(number);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        [DataRow("1,2,3", 6)]
        [DataRow("3\n2", 5)]
        [DataRow("1\n2,3", 6)]
        [DataRow("1\n2\n3,4,5", 15)]
        public void AddReturSumWhenSuppliedNumbersInStringWithNewLineAsDelimiter(string numbers, int expectedResult)
        {
            var result = Calculator.Add(numbers);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        [DataRow("0,1", 1)]
        [DataRow("0,1,1", 2)]
        [DataRow("0,2", 2)]
        [DataRow("0,2,2", 4)]
        [DataRow("0,3", 3)]
        [DataRow("0,3,2", 5)]
        [DataRow("0,3,3", 6)]
        public void AddReturnSumWhenSuppliedMultipleNumbersInString(string numbers, int expectedResult)
        {
            var result = Calculator.Add(numbers);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        [DataRow("0,3,1001", 3)]
        [DataRow("0,3,1000", 1003)]
        public void AddReturnSumByIgnoringMoreThanThousandWhenSuppliedMultipleNumbersInString(string numbers, int expectedResult)
        {
            var result = Calculator.Add(numbers);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        [DataRow("//*\n1*2", 3)]
        [DataRow("//;\n1;2", 3)]
        [DataRow("//;\n1;2;3;4;5;6;7;8;9;10", 55)]
        public void AddWhenGivenDefinedDelimiterUsesThatDelimiter(string input, int expectation)
        {
            var result = Calculator.Add(input);
            Assert.AreEqual(result, expectation);
        }

        [TestMethod]
        [DataRow("1,-1", -1)]
        public void AddThrowArgumentExceptionWhenSuppliedStringDoesNotMeetRule(string numbers, int beyondRuleNumber)
        {
            Assert.ThrowsException<ArgumentException>(() => Calculator.Add(numbers));
        }
    }
}
