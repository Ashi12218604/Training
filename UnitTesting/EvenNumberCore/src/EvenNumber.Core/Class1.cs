using System;

namespace EvenNumber.Core
{
    public class EvenNumberService
    {
        // Sum of first (n-1) integers
        public int SumOfNIntegers(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number must be non-negative");
            }

            return (number * (number - 1)) / 2;
        }

        // Reverse a string
        public string ReverseString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null or empty");
            }

            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
