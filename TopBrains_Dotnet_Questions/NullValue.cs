using System;
using System.Globalization;

public class Solution
{
    public static double? AverageNonNull(double?[] values)
    {
        double sum = 0;
        int count = 0;

        for (int i = 0; i < values.Length; i++)
        {
            if (values[i].HasValue)
            {
                sum += values[i].Value;
                count++;
            }
        }

        if (count == 0)
            return null;

        double avg = sum / count;

        return Math.Round(avg, 2, MidpointRounding.AwayFromZero);
    }

    public static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        double?[] values = new double?[n];

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            if (input == "null")
                values[i] = null;
            else
                values[i] = Convert.ToDouble(input);
        }

        double? result = AverageNonNull(values);

        if (result.HasValue)
            Console.WriteLine(result.Value.ToString("F2", CultureInfo.InvariantCulture));
        else
            Console.WriteLine("null");
    }
}
