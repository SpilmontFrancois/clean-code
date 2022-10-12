using System;

namespace CalculatorTest
{
    internal class Calculator
    {
        internal int Add(int number1, int number2)
        {
            if (number1 < 0 || number2 < 0)
                throw new NegativeException("Les paramètres ne peuvent pas être négatifs");
            return number1 + number2;
        }

        internal int Divide(int number1, int number2)
        {
            if (number1 < 0 || number2 < 0)
                throw new NegativeException("Les paramètres ne peuvent pas être négatifs");
            return number1 / number2;
        }

        internal int Multiply(int number1, int number2)
        {
            if (number1 < 0 || number2 < 0)
                throw new NegativeException("Les paramètres ne peuvent pas être négatifs");
            return number1 * number2;
        }

        internal int Substract(int number1, int number2)
        {
            if (number1 < 0 || number2 < 0)
                throw new NegativeException("Les paramètres ne peuvent pas être négatifs");
            else if (number2 == 0)
                throw new DivideByZeroException();
            return number1 - number2;
        }
    }
}