using System;
using System.Collections.Generic;
public class Hashsets
{
    public static void hs()
    {
        HashSet<int> set=new HashSet<int>();
        set.Add(1);
        set.Add(1);
        set.Add(2);
        foreach (int x in set)
        {
            Console.WriteLine(x);
        } 
    
    }
}