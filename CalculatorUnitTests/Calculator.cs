using System;

namespace CalculatorUnitTests_MsTests
{
    public static class Calculator
    {
        internal static object Add(string numbers)
        {
            char? delimiter = null;

            if (numbers == "" || numbers == null)
                return 0;
            else if (numbers.StartsWith("//") && numbers.Contains("\n"))
            {
                delimiter = numbers[2];
                numbers = numbers.Split('\n')[1];
            }

            if (numbers.Contains(",") || numbers.Contains("\n") || delimiter != null)
            {
                string[] array;

                if (delimiter != null)
                    array = numbers.Split((char)delimiter);
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