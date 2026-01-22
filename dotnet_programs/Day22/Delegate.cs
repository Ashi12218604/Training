using System;

public delegate int AddDelegate(int a, int b);
public delegate int SubtDelegate(int c, int d);
public delegate int FindLengthDelegate(string k);

public class Delegates
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Sub(int c, int d)
    {
        return c - d;
    }

    public static int FindLength(string k)
    {
        return k.Length;
    }
}
