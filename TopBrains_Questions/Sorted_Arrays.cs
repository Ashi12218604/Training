using System;
using System.Collections.Generic;
public class Solution
{
    public static T[] MergeSorted<T>(T[] a, T[] b) where T : IComparable<T>
    {
        int n = a.Length;
        int m = b.Length;
        T[] result = new T[n + m];
        int i = 0, j = 0, k = 0;
        while (i < n && j < m)
        {
            if (a[i].CompareTo(b[j]) <= 0)
                result[k++] = a[i++];
            else
                result[k++] = b[j++];
        }
        while (i < n)
            result[k++] = a[i++];

        while (j < m)
            result[k++] = b[j++];

        return result;
    }
    public static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] a = new int[n];
        for (int i = 0; i < n; i++)
            a[i] = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());
        int[] b = new int[m];
        for (int i = 0; i < m; i++)
            b[i] = Convert.ToInt32(Console.ReadLine());
        int[] merged = MergeSorted(a, b);
        for (int i = 0; i < merged.Length; i++)
        {
            if (i > 0)
                Console.Write(" ");
            Console.Write(merged[i]);
        }
    }
}
