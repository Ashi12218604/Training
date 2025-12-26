using System;
using System.Collections.Generic;
public class Sortedlists
{
    public static void Stl()
    {
        SortedList<string,string> list=new SortedList<string, string>();
        list.Add("b","B");
        list.Add("a","A");
        foreach (KeyValuePair<string, string> kv in list)
{
    Console.WriteLine($"{kv.Key} : {kv.Value}");
}
// foreach (string key in list.Keys)
// {
//     Console.WriteLine(key);
// }

    }
}