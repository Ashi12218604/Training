using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<int,Product> dict=new Dictionary<int,Product>();
        int n=int.Parse(Console.ReadLine());
        for(int i=0;i<n;i++)
        {
        string[] input=Console.ReadLine().Split();
        int id=int.Parse(input[0]);
        string name=input[1];
        int stock=int.Parse(input[2]);
        
        if(dict.ContainsKey(id))
        {
            dict[id].Stock+=stock;
        }
        else
        {
            dict.Add(id,new Product(id,name,stock));
        }
        }
        var result=dict.OrderByDescending(e=>e.Value.Stock).First();
        Console.WriteLine($"{result.Value.Name},{result.Value.Stock}");
    
        
    }
}