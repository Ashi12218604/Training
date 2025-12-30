using System;
using System.Collections;
public class Hashtables
{
    public static void hs()
    {
        Hashtable ht=new Hashtable();
        ht.Add(1,"Admin");
        ht.Add(2,"User");
        Console.WriteLine(ht[1]);
    }
}