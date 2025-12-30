using System;
interface IPrintable
{
    void Print();
    static int c=0;

    // void Scan();
}

class Report : IPrintable
{
    public void Print()
    {
        Console.WriteLine("Printing report");
    }
}