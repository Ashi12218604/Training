using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        IBook b=new IBook();
      Console.WriteLine("Book Info:");
      Console.WriteLine("Book Name:"+b.Title);
    }
}