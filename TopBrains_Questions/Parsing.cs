using System;

public class Solution
{
    public static int SumParsedIntegers(string[] tokens)
    {
        int sum = 0;

        for (int i = 0; i < tokens.Length; i++)
        {
            int value;
            if (int.TryParse(tokens[i], out value))
                sum += value;
        }

        return sum;
    }

    public static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] tokens = new string[n];

        for (int i = 0; i < n; i++)
            tokens[i] = Console.ReadLine();

        Console.WriteLine(SumParsedIntegers(tokens));
    }
}
