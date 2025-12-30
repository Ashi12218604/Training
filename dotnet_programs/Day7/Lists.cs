using System;
using System.Collections.Generic;
using System.Collections;
public class Lists
{
    public static void ls()
    {
        List<int> arr=new List<int>();
        arr.Add(10);
        arr.Add(20);
        foreach(int x in arr)
        {
            Console.WriteLine(x);
        }
        ArrayList l1=new ArrayList();
        l1.Add("Hello");
        l1.Add(20);
        foreach(object i in l1)
        {
            Console.WriteLine(i);
        }

    }
}