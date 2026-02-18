using System;
using System.Collections.Generic;
using System.Collections;
public class Program
{
    public static void Main(string[] args)
    {
        List<Product> p=new List<Product>
        {
          new Product(1,"Ashi",500.0f,10.11f),
          new Product(2,"Sanjana",null,20.3f),
          new Product(3,"Raima",null, 6.5f),
          new Product(4,"Shahid",1100.45f,2.5f)  
        };
        ArrayList l=new ArrayList(p);
         double final=0;
        foreach(Product pr in l)
        {
            String res;
            if(pr.Price==null)
            res="Price Not Available";
            else
            {
                res=Math.Round(pr.Price.Value,2).ToString();
            double price = pr.Price.Value;
            if(pr.DiscountPercentage>10)
            {
              final =price -(price * pr.DiscountPercentage / 100);
            }
            else
            {
                final=price;
            }
            }
            Console.WriteLine($"Id:{pr.Id},Name:{pr.Name},Price:{res},Final Price:{Math.Round(final,2)}");

        }
        
    }
}
