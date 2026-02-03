using System;

public class Solution
{
    public static int[] MultiplicationRow(int n, int upto)
    {
        int[] row = new int[upto];

        for (int i = 0; i < upto; i++)
            row[i] = n * (i + 1);

        return row;
    }

    public static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int upto = Convert.ToInt32(Console.ReadLine());

        int[] result = MultiplicationRow(n, upto);

        for (int i = 0; i < result.Length; i++)
        {
            if (i > 0)
                Console.Write(" ");
            Console.Write(result[i]);
        }
    }
}
