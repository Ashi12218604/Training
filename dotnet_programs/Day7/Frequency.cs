using System;
using System.Collections.Generic;
class Frequency
{
    public static void freq()
    {
        int[] arr={1, 2, 3, 2, 1, 4, 2};
        Dictionary<int, int> freq=new Dictionary<int, int>();
        foreach (int num in arr)
        {
            if (freq.ContainsKey(num))
                freq[num]++;
            else
                freq[num]=1;
        }
        foreach (var kv in freq)
        {
            Console.WriteLine($"{kv.Key}:{kv.Value}");
        }
    }
}
