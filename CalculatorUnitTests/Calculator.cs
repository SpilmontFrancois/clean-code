using System;

namespace CalculatorUnitTests_MsTests
{
    public static class Calculator
    {
        public static int Add(string numbers)
        {
            return string.IsNullOrEmpty(numbers) ? 0 : GetSum(numbers);
        }

        private static int GetSum(string numbers)
        {
            char? customDelimiter = null;

            if (numbers.StartsWith("//") && numbers.Contains("\n"))
            {
                customDelimiter = numbers[2];
                numbers = numbers.Split('\n')[1];
            }

            if (numbers.Contains(",") || numbers.Contains("\n") || customDelimiter != null)
            {
                string[] array;

                if (customDelimiter != null)
                    array = numbers.Split((char)customDelimiter);
                else
                    array = numbers.Split(new Char[] { ',', '\n' });

                int total = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (int.Parse(array[i]) < 0)
                        throw new ArgumentException();
                    else if (int.Parse(array[i]) <= 1000)
                        total += int.Parse(array[i]);
                }

                return total;
            }

            return int.Parse(numbers);
        }
    }
}