using System;

public class Solution
{
    public static int SumIntegers(object[] values)
    {
        int sum = 0;

        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] is int x)
                sum += x;
        }

        return sum;
    }

    public static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        object[] values = new object[n];

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int intVal))
                values[i] = intVal;
            else if (bool.TryParse(input, out bool boolVal))
                values[i] = boolVal;
            else if (input == "null")
                values[i] = null;
            else
                values[i] = input;
        }

        Console.WriteLine(SumIntegers(values));
    }
}
