using System;
using System.Collections.Generic;

public static class Extensions
{
    public static string[] DistinctById(this string[] items)
    {
        HashSet<string> seen = new HashSet<string>();
        List<string> result = new List<string>();

        for (int i = 0; i < items.Length; i++)
        {
            string[] parts = items[i].Split(':');

            if (parts.Length != 2)
                continue;

            string id = parts[0];
            string name = parts[1];

            if (!seen.Contains(id))
            {
                seen.Add(id);
                result.Add(name);
            }
        }

        return result.ToArray();
    }
}

public class Solution
{
    public static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] items = new string[n];

        for (int i = 0; i < n; i++)
            items[i] = Console.ReadLine();

        string[] result = items.DistinctById();

        for (int i = 0; i < result.Length; i++)
        {
            if (i > 0)
                Console.Write(" ");
            Console.Write(result[i]);
        }
    }
}
