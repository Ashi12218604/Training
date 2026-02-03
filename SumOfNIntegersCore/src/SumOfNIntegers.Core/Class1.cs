using System;

namespace SumOfNIntegers.Core
{
    public class SumService
    {
        public int SumOfNIntegers(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("n must be non-negative");
            }
            return (n * (n - 1)) / 2;
        }
    }
}
