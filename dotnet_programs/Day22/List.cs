using System;
using System.Collections.Generic;
public class Export
{    public static void ListAdd()
    {
        List<int> l = new List<int>();
        List<int> l2 = new List<int>();
        List<int> l3 = new List<int>();
        for (int i = 1; i <= 100; i++)
        {
            if (i % 2==0)
                l.Add(i);
            else if (i%3==0)
                l2.Add(i);
            else
                l3.Add(i);
        }

        Console.WriteLine("Divisible by 2: " + string.Join(", ", l));
        Console.WriteLine("Divisible by 3: " + string.Join(", ", l2));
        Console.WriteLine("Divisible by None: " + string.Join(", ", l3));
    }
}
