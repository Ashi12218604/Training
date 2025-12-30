using System;
public class Exists
{
    public static void Ex()
    {
        int[] src ={10,15,20,25};
        bool found=Array.Exists(src,x=>x>25);
        Console.Write(found);
    }
}