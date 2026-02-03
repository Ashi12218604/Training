using System;

namespace ReverseString.Core
{
    public class StringService
    {
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
